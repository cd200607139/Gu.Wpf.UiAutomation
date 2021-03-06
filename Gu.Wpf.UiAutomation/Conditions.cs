namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Linq;
    using System.Windows.Automation;

    public static class Conditions
    {
        public static Condition TrueCondition { get; } = Condition.TrueCondition;

        public static Condition Button { get; } = new AndCondition(
            ByControlType(ControlType.Button),
            new PropertyCondition(AutomationElement.IsTogglePatternAvailableProperty, false));

        public static Condition Calendar { get; } = ByControlType(ControlType.Calendar);

        public static Condition CalendarDayButton { get; } = ByClassName(nameof(CalendarDayButton));

        public static Condition CheckBox { get; } = ByControlType(ControlType.CheckBox);

        public static Condition ComboBox { get; } = ByControlType(ControlType.ComboBox);

        public static Condition ContextMenu { get; } = ByClassName(nameof(ContextMenu));

        public static Condition ControlTypeCustom { get; } = ByControlType(ControlType.Custom);

        public static Condition DataGrid { get; } = ByClassName(nameof(DataGrid));

        public static Condition DataGridCell { get; } = ByClassName(nameof(DataGridCell));

        public static Condition DataGridColumnHeadersPresenter { get; } = ByClassName(nameof(DataGridColumnHeadersPresenter));

        public static Condition DataGridColumnHeader { get; } = ByClassName(nameof(DataGridColumnHeader));

        public static Condition DataGridRow { get; } = ByClassName(nameof(DataGridRow));

        public static Condition DataGridRowHeader { get; } = ByClassName(nameof(DataGridRowHeader));

        public static Condition DataGridDetailsPresenter { get; } = ByClassName(nameof(DataGridDetailsPresenter));

        public static Condition DataItem { get; } = ByControlType(ControlType.DataItem);

        public static Condition DatePicker { get; } = new AndCondition(ByControlType(ControlType.Custom), ByClassName(nameof(DatePicker)));

        public static Condition Frame { get; } = ByClassName(nameof(Frame));

        public static Condition ControlTypeDocument { get; } = ByControlType(ControlType.Document);

        public static AndCondition Expander { get; } = new AndCondition(ByControlType(ControlType.Group), ByClassName(nameof(Expander)));

        public static Condition GridSplitter { get; } = ByClassName(nameof(GridSplitter));

        public static Condition GridViewCell { get; } = new AndCondition(
            new PropertyCondition(AutomationElement.IsTableItemPatternAvailableProperty, true),
            new PropertyCondition(AutomationElement.IsGridItemPatternAvailableProperty, true));

        public static Condition GridViewColumnHeader { get; } = ByClassName(nameof(GridViewColumnHeader));

        public static Condition GridViewRowHeader { get; } = ByClassName(nameof(GridViewRowHeader));

        public static Condition GridViewHeaderRowPresenter { get; } = ByClassName(nameof(GridViewHeaderRowPresenter));

        public static Condition GroupBox { get; } = new AndCondition(ByControlType(ControlType.Group), ByClassName(nameof(GroupBox)));

        public static Condition Header { get; } = ByControlType(ControlType.Header);

        public static Condition HeaderItem { get; } = ByControlType(ControlType.HeaderItem);

        public static Condition HeaderSite { get; } = new PropertyCondition(AutomationElement.AutomationIdProperty, nameof(HeaderSite));

        public static Condition NotHeaderSite { get; } = new NotCondition(HeaderSite);

        public static Condition HorizontalScrollBar { get; } = new AndCondition(ByControlType(ControlType.ScrollBar), new NotCondition(ByAutomationId(nameof(VerticalScrollBar))));

        public static Condition VerticalScrollBar { get; } = new AndCondition(ByControlType(ControlType.ScrollBar), new NotCondition(ByAutomationId(nameof(HorizontalScrollBar))));

        public static Condition Hyperlink { get; } = ByControlType(ControlType.Hyperlink);

        public static Condition Image { get; } = ByControlType(ControlType.Image);

        public static Condition Label { get; } = new AndCondition(
            ByControlType(ControlType.Text),
            new OrCondition(
                ByClassName(nameof(Text)),
                ByClassName("Static")));

        public static Condition ListBox { get; } = ByClassName(nameof(ListBox));

        public static Condition ListBoxItem { get; } = ByClassName(nameof(ListBoxItem));

        public static Condition ListView { get; } = ByClassName(nameof(ListView));

        public static Condition ListViewItem { get; } = ByClassName(nameof(ListViewItem));

        public static Condition Menu { get; } = ByControlType(ControlType.Menu);

        public static Condition MenuBar { get; } = ByControlType(ControlType.MenuBar);

        public static Condition MenuItem { get; } = ByControlType(ControlType.MenuItem);

        public static Condition MessageBox { get; } = ByClassName("#32770");

        public static Condition OpenFileDialog { get; } = ByClassName("#32770");

        public static Condition SaveFileDialog { get; } = ByClassName("#32770");

        public static Condition ModalWindow { get; } = new AndCondition(
            ByControlType(ControlType.Window),
            new PropertyCondition(WindowPatternIdentifiers.IsModalProperty, true));

        public static Condition Pane { get; } = ByControlType(ControlType.Pane);

        public static Condition PasswordBox { get; } = ByClassName(nameof(PasswordBox));

        public static Condition Popup { get; } = new AndCondition(
            ByControlType(ControlType.Window),
            Conditions.ByName(string.Empty),
            Conditions.ByClassName("Popup"));

        public static Condition ProgressBar { get; } = ByControlType(ControlType.ProgressBar);

        public static Condition RadioButton { get; } = ByControlType(ControlType.RadioButton);

        public static Condition RepeatButton { get; } = ByClassName(nameof(RepeatButton));

        public static Condition RichTextBox { get; } = ByClassName(nameof(RichTextBox));

        public static Condition ScrollBar { get; } = ByControlType(ControlType.ScrollBar);

        public static Condition ScrollViewer { get; } = ByClassName(nameof(ScrollViewer));

        public static Condition Separator { get; } = ByControlType(ControlType.Separator);

        public static Condition Slider { get; } = ByControlType(ControlType.Slider);

        public static Condition Spinner { get; } = ByControlType(ControlType.Spinner);

        public static Condition SplitButton { get; } = ByControlType(ControlType.SplitButton);

        public static Condition StatusBar { get; } = ByControlType(ControlType.StatusBar);

        public static Condition TabControl { get; } = ByControlType(ControlType.Tab);

        public static Condition TabItem { get; } = ByControlType(ControlType.TabItem);

        public static Condition ControlTypeTable { get; } = ByControlType(ControlType.Table);

        public static Condition TextBlock { get; } = new AndCondition(ByControlType(ControlType.Text), ByClassName(nameof(TextBlock)));

        /// <summary>
        /// For finding textblocks and labels.
        /// </summary>
        public static Condition Text { get; } = ByControlType(ControlType.Text);

        public static Condition TextBox { get; } = ByClassName(nameof(TextBox));

        public static Condition TextBoxBase { get; } = ByControlType(ControlType.Edit);

        public static Condition Thumb { get; } = ByControlType(ControlType.Thumb);

        public static Condition TitleBar { get; } = ByControlType(ControlType.TitleBar);

        public static Condition ToggleButton { get; } = new AndCondition(
            ByControlType(ControlType.Button),
            new PropertyCondition(AutomationElement.IsTogglePatternAvailableProperty, true));

        public static Condition ToolBar { get; } = ByControlType(ControlType.ToolBar);

        public static Condition ToolTip { get; } = ByControlType(ControlType.ToolTip);

        public static Condition TreeView { get; } = ByControlType(ControlType.Tree);

        public static Condition TreeViewItem { get; } = ByControlType(ControlType.TreeItem);

        public static Condition UserControl { get; } = new AndCondition(
            ByControlType(ControlType.Custom),
            new PropertyCondition(AutomationElement.IsContentElementProperty, true),
            new PropertyCondition(AutomationElement.IsControlElementProperty, true));

        public static Condition Window { get; } = ByControlType(ControlType.Window);

        public static PropertyCondition IsKeyboardFocusable { get; } = new PropertyCondition(AutomationElement.IsKeyboardFocusableProperty, true);

        public static PropertyCondition IsTableItemPatternAvailable { get; } = new PropertyCondition(AutomationElement.IsTableItemPatternAvailableProperty, true);

        public static PropertyCondition IsScrollItemPatternAvailable { get; } = new PropertyCondition(AutomationElement.IsScrollItemPatternAvailableProperty, true);

        public static PropertyCondition IsScrollPatternAvailable { get; } = new PropertyCondition(AutomationElement.IsScrollPatternAvailableProperty, true);

        public static PropertyCondition ByAutomationId(string automationId)
        {
            return new PropertyCondition(AutomationElementIdentifiers.AutomationIdProperty, automationId);
        }

        public static PropertyCondition ByClassName(string className)
        {
            return new PropertyCondition(AutomationElementIdentifiers.ClassNameProperty, className);
        }

        public static PropertyCondition ByControlType(ControlType controlType)
        {
            return new PropertyCondition(AutomationElementIdentifiers.ControlTypeProperty, controlType);
        }

        public static PropertyCondition ByLocalizedControlType(string localizedControlType)
        {
            return new PropertyCondition(AutomationElementIdentifiers.LocalizedControlTypeProperty, localizedControlType);
        }

        public static PropertyCondition ByHelpTextProperty(string helpText)
        {
            return new PropertyCondition(AutomationElementIdentifiers.HelpTextProperty, helpText);
        }

        public static PropertyCondition ByName(string name)
        {
            return new PropertyCondition(AutomationElementIdentifiers.NameProperty, name);
        }

        public static OrCondition ByNameOrAutomationId(string key)
        {
            return new OrCondition(
                ByName(key),
                ByAutomationId(key));
        }

        public static PropertyCondition ByProcessId(int processId)
        {
            return new PropertyCondition(AutomationElementIdentifiers.ProcessIdProperty, processId);
        }

        public static PropertyCondition ByValue(string value)
        {
            return new PropertyCondition(ValuePatternIdentifiers.ValueProperty, value);
        }

        public static string Description(this Condition condition)
        {
            if (condition is null)
            {
                throw new ArgumentNullException(nameof(condition));
            }

            switch (condition)
            {
                case PropertyCondition propertyCondition:
                    {
                        if (Equals(propertyCondition.Property, AutomationElementIdentifiers.ControlTypeProperty))
                        {
                            // ReSharper disable once PossibleNullReferenceException
                            return $"ControlType == {ControlType.LookupById((int)propertyCondition.Value).ProgrammaticName.TrimStart("ControlType.")}";
                        }

                        return $"{propertyCondition.Property.ProgrammaticName.TrimStart("AutomationElementIdentifiers.").TrimEnd("Property")} == {propertyCondition.Value}";
                    }

                case AndCondition andCondition:
                    return $"({string.Join(" && ", andCondition.GetConditions().Select(x => x.Description()))})";
                case OrCondition orCondition:
                    return $"({string.Join(" || ", orCondition.GetConditions().Select(x => x.Description()))})";
                case NotCondition notCondition:
                    return $"!{notCondition.Condition.Description()}";
                case var c when c == Condition.TrueCondition:
                    return "Condition.TrueCondition";
                case var c when c == Condition.FalseCondition:
                    return "Condition.FalseCondition";
                default:
                    return condition.ToString()!;
            }
        }

        internal static bool IsMatch(AutomationElement element, Condition condition)
        {
            switch (condition)
            {
                case PropertyCondition propertyCondition:
                    {
                        var value = element.GetCurrentPropertyValue(propertyCondition.Property);
                        if (Equals(propertyCondition.Property, AutomationElement.ControlTypeProperty) &&
                            value is ControlType controlType &&
                            propertyCondition.Value is int id)
                        {
                            return controlType.Id == id;
                        }

                        return propertyCondition.Flags switch
                        {
                            PropertyConditionFlags.None => Equals(value, propertyCondition.Value),
                            PropertyConditionFlags.IgnoreCase => string.Equals((string)value, (string)propertyCondition.Value, StringComparison.OrdinalIgnoreCase),
                            _ => throw new ArgumentOutOfRangeException(nameof(condition), propertyCondition.Flags, "Unknown flags."),
                        };
                    }

                case AndCondition andCondition:
                    return andCondition.GetConditions().All(c => IsMatch(element, c));
                case OrCondition orCondition:
                    return orCondition.GetConditions().Any(c => IsMatch(element, c));
                case NotCondition notCondition:
                    return !IsMatch(element, notCondition.Condition);
                case var c when c == Condition.TrueCondition:
                    return true;
                case var c when c == Condition.FalseCondition:
                    return false;
                default:
                    throw new ArgumentOutOfRangeException(nameof(condition), condition, "Condition not suported");
            }
        }
    }
}
