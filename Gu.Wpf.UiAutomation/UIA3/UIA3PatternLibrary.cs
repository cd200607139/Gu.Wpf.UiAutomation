﻿namespace Gu.Wpf.UiAutomation.UIA3
{
    public class UIA3PatternLibrary : IPatternLibrary
    {
        public PatternId AnnotationPattern => Patterns.AnnotationPattern.Pattern;

        public PatternId DockPattern => Patterns.DockPattern.Pattern;

        public PatternId DragPattern => Patterns.DragPattern.Pattern;

        public PatternId DropTargetPattern => Patterns.DropTargetPattern.Pattern;

        public PatternId ExpandCollapsePattern => Patterns.ExpandCollapsePattern.Pattern;

        public PatternId GridItemPattern => Patterns.GridItemPattern.Pattern;

        public PatternId GridPattern => Patterns.GridPattern.Pattern;

        public PatternId InvokePattern => Patterns.InvokePattern.Pattern;

        public PatternId ItemContainerPattern => Patterns.ItemContainerPattern.Pattern;

        public PatternId LegacyIAccessiblePattern => Patterns.LegacyIAccessiblePattern.Pattern;

        public PatternId MultipleViewPattern => Patterns.MultipleViewPattern.Pattern;

        public PatternId ObjectModelPattern => Patterns.ObjectModelPattern.Pattern;

        public PatternId RangeValuePattern => Patterns.RangeValuePattern.Pattern;

        public PatternId ScrollItemPattern => Patterns.ScrollItemPattern.Pattern;

        public PatternId ScrollPattern => Patterns.ScrollPattern.Pattern;

        public PatternId SelectionItemPattern => Patterns.SelectionItemPattern.Pattern;

        public PatternId SelectionPattern => Patterns.SelectionPattern.Pattern;

        public PatternId SpreadsheetItemPattern => Patterns.SpreadsheetItemPattern.Pattern;

        public PatternId SpreadsheetPattern => Patterns.SpreadsheetPattern.Pattern;

        public PatternId StylesPattern => Patterns.StylesPattern.Pattern;

        public PatternId SynchronizedInputPattern => Patterns.SynchronizedInputPattern.Pattern;

        public PatternId TableItemPattern => Patterns.TableItemPattern.Pattern;

        public PatternId TablePattern => Patterns.TablePattern.Pattern;

        public PatternId TextChildPattern => Patterns.TextChildPattern.Pattern;

        public PatternId TextEditPattern => Patterns.TextEditPattern.Pattern;

        public PatternId Text2Pattern => Patterns.Text2Pattern.Pattern;

        public PatternId TextPattern => Patterns.TextPattern.Pattern;

        public PatternId TogglePattern => Patterns.TogglePattern.Pattern;

        public PatternId Transform2Pattern => Patterns.Transform2Pattern.Pattern;

        public PatternId TransformPattern => Patterns.TransformPattern.Pattern;

        public PatternId ValuePattern => Patterns.ValuePattern.Pattern;

        public PatternId VirtualizedItemPattern => Patterns.VirtualizedItemPattern.Pattern;

        public PatternId WindowPattern => Patterns.WindowPattern.Pattern;

        public PatternId[] AllForCurrentFramework => new[]
        {
            this.AnnotationPattern,
            this.DockPattern,
            this.DragPattern,
            this.DropTargetPattern,
            this.ExpandCollapsePattern,
            this.GridItemPattern,
            this.GridPattern,
            this.InvokePattern,
            this.ItemContainerPattern,
            this.LegacyIAccessiblePattern,
            this.MultipleViewPattern,
            this.ObjectModelPattern,
            this.RangeValuePattern,
            this.ScrollItemPattern,
            this.ScrollPattern,
            this.SelectionItemPattern,
            this.SelectionPattern,
            this.SpreadsheetItemPattern,
            this.SpreadsheetPattern,
            this.StylesPattern,
            this.SynchronizedInputPattern,
            this.TableItemPattern,
            this.TablePattern,
            this.TextChildPattern,
            this.TextEditPattern,
            this.Text2Pattern,
            this.TextPattern,
            this.TogglePattern,
            this.Transform2Pattern,
            this.TransformPattern,
            this.ValuePattern,
            this.VirtualizedItemPattern,
            this.WindowPattern
        };
    }
}