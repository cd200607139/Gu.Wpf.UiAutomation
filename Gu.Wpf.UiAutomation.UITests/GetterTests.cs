﻿namespace Gu.Wpf.UiAutomation.UITests
{
    using Gu.Wpf.UiAutomation.Definitions;
    using Gu.Wpf.UiAutomation.Exceptions;
    using Gu.Wpf.UiAutomation.UITests.TestFramework;
    using NUnit.Framework;
    using NUnit.Framework.Constraints;

    [TestFixture(AutomationType.UIA2, TestApplicationType.Custom)]
    [TestFixture(AutomationType.UIA3, TestApplicationType.Custom)]
    public class GetterTests : UITestBase
    {
        public GetterTests(AutomationType automationType, TestApplicationType appType)
            : base(automationType, appType)
        {
        }

        protected override Application StartApplication()
        {
            return Application.Launch("notepad.exe");
        }

        [Test]
        public void CorrectPattern()
        {
            var mainWindow = this.App.GetMainWindow(this.Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowPattern = mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.WindowPattern);
            Assert.That(windowPattern, Is.Not.Null);
        }

        [Test]
        public void CorrectPatternCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(this.Automation.PatternLibrary.WindowPattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowPattern = mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.WindowPattern);
                Assert.That(windowPattern, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedPattern()
        {
            var mainWindow = this.App.GetMainWindow(this.Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.ExpandCollapsePattern);
            Assert.That(testDelegate, Throws.TypeOf<PatternNotSupportedException>().With.Message.Contains("ExpandCollapse"));
        }

        [Test]
        public void UnsupportedPatternCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(this.Automation.PatternLibrary.ExpandCollapsePattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.ExpandCollapsePattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotSupportedException>().With.Message.Contains("ExpandCollapse"));
            }
        }

        [Test]
        public void CorrectPatternUncached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(this.Automation.PatternLibrary.ExpandCollapsePattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.WindowPattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotCachedException>().With.Message.Contains("Window"));
            }
        }

        [Test]
        public void UnsupportedPatternUnCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Patterns.Add(this.Automation.PatternLibrary.WindowPattern);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetNativePattern<object>(this.Automation.PatternLibrary.ExpandCollapsePattern);
                Assert.That(testDelegate, Throws.TypeOf<PatternNotCachedException>().With.Message.Contains("ExpandCollapse"));
            }
        }

        [Test]
        public void CorrectProperty()
        {
            var mainWindow = this.App.GetMainWindow(this.Automation);
            Assert.That(mainWindow, Is.Not.Null);
            var windowProperty = mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.Window.CanMaximize);
            Assert.That(windowProperty, Is.Not.Null);
        }

        [Test]
        public void CorrectPropertyCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(this.Automation.PropertyLibrary.Window.CanMaximize);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                var windowProperty = mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.Window.CanMaximize);
                Assert.That(windowProperty, Is.Not.Null);
            }
        }

        [Test]
        public void UnsupportedProperty()
        {
            var mainWindow = this.App.GetMainWindow(this.Automation);
            Assert.That(mainWindow, Is.Not.Null);
            ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            Assert.That(testDelegate, Throws.TypeOf<PropertyNotSupportedException>().With.Message.Contains("ExpandCollapseState"));
        }

        [Test]
        public void UnsupportedPropertyCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(this.Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotSupportedException>().With.Message.Contains("ExpandCollapseState"));
            }
        }

        [Test]
        public void CorrectPropertyUncached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(this.Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.Window.CanMaximize);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotCachedException>().With.Message.Contains("CanMaximize"));
            }
        }

        [Test]
        public void UnsupportedPropertyUnCached()
        {
            var cacheRequest = new CacheRequest();
            cacheRequest.AutomationElementMode = AutomationElementMode.None;
            cacheRequest.TreeScope = TreeScope.Element;
            cacheRequest.Properties.Add(this.Automation.PropertyLibrary.Window.CanMaximize);
            using (cacheRequest.Activate())
            {
                var mainWindow = this.App.GetMainWindow(this.Automation);
                Assert.That(mainWindow, Is.Not.Null);
                ActualValueDelegate<object> testDelegate = () => mainWindow.BasicAutomationElement.GetPropertyValue(this.Automation.PropertyLibrary.ExpandCollapse.ExpandCollapseState);
                Assert.That(testDelegate, Throws.TypeOf<PropertyNotCachedException>().With.Message.Contains("ExpandCollapseState"));
            }
        }
    }
}
