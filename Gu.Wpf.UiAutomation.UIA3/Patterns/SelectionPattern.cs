﻿namespace Gu.Wpf.UiAutomation.UIA3.Patterns
{
    using Gu.Wpf.UiAutomation.Identifiers;
    using Gu.Wpf.UiAutomation.Patterns;
    using Gu.Wpf.UiAutomation.UIA3.Converters;
    using Gu.Wpf.UiAutomation.UIA3.Identifiers;
    using UIA = Interop.UIAutomationClient;

    public class SelectionPattern : SelectionPatternBase<UIA.IUIAutomationSelectionPattern>
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, UIA.UIA_PatternIds.UIA_SelectionPatternId, "Selection", AutomationObjectIds.IsSelectionPatternAvailableProperty);
        public static readonly PropertyId CanSelectMultipleProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionCanSelectMultiplePropertyId, "CanSelectMultiple");
        public static readonly PropertyId IsSelectionRequiredProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionIsSelectionRequiredPropertyId, "IsSelectionRequired");
        public static readonly PropertyId SelectionProperty = PropertyId.Register(AutomationType.UIA3, UIA.UIA_PropertyIds.UIA_SelectionSelectionPropertyId, "Selection").SetConverter(AutomationElementConverter.NativeArrayToManaged);
        public static readonly EventId InvalidatedEvent = EventId.Register(AutomationType.UIA3, UIA.UIA_EventIds.UIA_Selection_InvalidatedEventId, "Invalidated");

        public SelectionPattern(BasicAutomationElementBase basicAutomationElement, UIA.IUIAutomationSelectionPattern nativePattern)
            : base(basicAutomationElement, nativePattern)
        {
        }
    }
}
