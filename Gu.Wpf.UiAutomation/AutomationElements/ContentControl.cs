namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    public class ContentControl : Control
    {
        public ContentControl(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// The content as text.
        /// </summary>
        public string Text => this.AutomationElement.Text();

        public UiElement Content
        {
            get
            {
                var children = this.FindAllChildren();
                if (children.Count < 1)
                {
                    throw new InvalidOperationException($"{this.GetType().Name} does not have content.");
                }

                if (children.Count > 1)
                {
                    throw new InvalidOperationException($"{this.GetType().Name} has an itemscontrol as content. Use ContentCollection");
                }

                return children[0];
            }
        }

        /// <summary>
        /// When the content is an itemscontrol.
        /// </summary>
        public IReadOnlyList<UiElement> ContentCollection => this.FindAllChildren().Skip(1).ToArray();
    }
}
