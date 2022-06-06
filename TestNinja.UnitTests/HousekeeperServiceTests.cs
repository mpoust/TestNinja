
using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HousekeeperServiceTests
    {
        // can be defined here because DateTimes are immutable - housekeeper on the other hand will need defined prior to each test run
        private readonly DateTime _statementDate = new DateTime(2017, 1, 1);
        private string _statementFileName;
        private Housekeeper _housekeeper;

        private Mock<IUnitOfWork> _mockUnitOfWork;
        private Mock<IStatementGenerator> _mockStatementGenerator;
        private Mock<IEmailSender> _mockEmailSender;
        private Mock<IXtraMessageBox> _mockMessageBox;
        
        private HousekeeperService _houseKeeperService;

        [SetUp]
        public void SetUp()
        {
            _housekeeper = new Housekeeper { Email = "fake@email.com", FullName = "Some Name", Oid = 1, StatementEmailBody = "Test Email Body Contents" };

            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockUnitOfWork
                .Setup(uow => uow.Query<Housekeeper>())
                .Returns(new List<Housekeeper>
                    {
                        _housekeeper
                    }.AsQueryable());

            _statementFileName = "fileName";
            _mockStatementGenerator = new Mock<IStatementGenerator>();
            _mockStatementGenerator
                .Setup(sg => sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate))
                .Returns(() =>_statementFileName);

            _mockEmailSender = new Mock<IEmailSender>();
            _mockMessageBox = new Mock<IXtraMessageBox>();

            _houseKeeperService = new HousekeeperService(
                _mockUnitOfWork.Object,
                _mockStatementGenerator.Object,
                _mockEmailSender.Object,
                _mockMessageBox.Object);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_GenerateStatements()
        {
            _houseKeeperService.SendStatementEmails(_statementDate);

            _mockStatementGenerator.Verify(sg => 
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate));
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_HouseKeeperEmailIsInvalid_ShouldNotGenerateStatement(string email)
        {
            _housekeeper.Email = null;

            _houseKeeperService.SendStatementEmails(_statementDate);

            _mockStatementGenerator.Verify(sg =>
                sg.SaveStatement(_housekeeper.Oid, _housekeeper.FullName, _statementDate), 
                Times.Never);
        }

        [Test]
        public void SendStatementEmails_WhenCalled_EmailStatements()
        {
            _houseKeeperService.SendStatementEmails(_statementDate);

            AssertEmailIsSent();
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void SendStatementEmails_StatementFilenameIsInvalid_ShouldNotEmailStatements(string invalidFilename)
        {
            _statementFileName = invalidFilename;
            _houseKeeperService.SendStatementEmails(_statementDate);

            AssertEmailNotSent();
        }

        [Test]
        public void SendStatementEmails_EmailSendingFails_DisplayAMessageBox()
        {
            _mockEmailSender.Setup(es => es.EmailFile(
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>(),
                It.IsAny<string>()
            )).Throws<Exception>();

            _houseKeeperService.SendStatementEmails(_statementDate);

            AssertMessageBoxDisplays();
        }

        private void AssertEmailIsSent()
        {
            _mockEmailSender.Verify(es => es.EmailFile(
                _housekeeper.Email,
                _housekeeper.StatementEmailBody,
                _statementFileName,
                It.IsAny<string>()));
        }

        private void AssertEmailNotSent()
        {
            _mockEmailSender.Verify(es => es.EmailFile(
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>(),
                    It.IsAny<string>()),
                Times.Never);
        }

        private void AssertMessageBoxDisplays()
        {
            _mockMessageBox.Verify(mb => mb.Show(It.IsAny<string>(), It.IsAny<string>(), MessageBoxButtons.OK));
        }
    }
}
