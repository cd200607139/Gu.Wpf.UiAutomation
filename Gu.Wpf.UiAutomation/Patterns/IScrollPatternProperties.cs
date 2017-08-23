namespace Gu.Wpf.UiAutomation.Patterns
{
    using Gu.Wpf.UiAutomation.Identifiers;

    public interface IScrollPatternProperties
    {
        PropertyId HorizontallyScrollable { get; }

        PropertyId HorizontalScrollPercent { get; }

        PropertyId HorizontalViewSize { get; }

        PropertyId VerticallyScrollable { get; }

        PropertyId VerticalScrollPercent { get; }

        PropertyId VerticalViewSize { get; }
    }
}