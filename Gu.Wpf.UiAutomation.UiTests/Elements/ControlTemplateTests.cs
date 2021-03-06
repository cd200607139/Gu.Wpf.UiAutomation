namespace Gu.Wpf.UiAutomation.UiTests.Elements
{
    using NUnit.Framework;

    public class ControlTemplateTests
    {
        private const string ExeFileName = "WpfApplication.exe";

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Application.KillLaunched(ExeFileName);
        }

        [Test]
        public void FindButton()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, "ControlTemplateWindow");
            var window = app.MainWindow;
            var button = window.FindButton("ButtonInControlTemplate");
            Assert.NotNull(button);
        }

        [Test]
        public void FindTextBlock()
        {
            using var app = Application.AttachOrLaunch(ExeFileName, "ControlTemplateWindow");
            var window = app.MainWindow;
            var textBlock = window.FindTextBlock("TextBlockInControlTemplate");
            Assert.NotNull(textBlock);
        }
    }
}
