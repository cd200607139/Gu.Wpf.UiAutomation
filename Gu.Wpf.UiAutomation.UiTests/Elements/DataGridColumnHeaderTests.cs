namespace Gu.Wpf.UiAutomation.UiTests.Elements
{
    using System.Windows.Automation;
    using NUnit.Framework;

    public class DataGridColumnHeaderTests
    {
        private const string ExeFileName = "WpfApplication.exe";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void Find()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, "SingleDataGridWindow");
            var window = app.MainWindow;
            var header = (DataGridColumnHeader)window.FindFirst(TreeScope.Descendants, Conditions.DataGridColumnHeader);
            Assert.IsInstanceOf<DataGridColumnHeader>(UiElement.FromAutomationElement(header.AutomationElement));
        }

        [Test]
        public void Properties()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, "SingleDataGridWindow");
            var window = app.MainWindow;
            var header = (DataGridColumnHeader)window.FindFirst(TreeScope.Descendants, Conditions.DataGridColumnHeader);
            Assert.AreEqual("IntValue", header.Text);
            Assert.NotNull(header.LeftHeaderGripper);
            Assert.NotNull(header.RightHeaderGripper);
        }
    }
}
