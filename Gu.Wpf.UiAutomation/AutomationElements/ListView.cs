namespace Gu.Wpf.UiAutomation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Automation;

    public class ListView : Selector
    {
        public ListView(AutomationElement automationElement)
            : base(automationElement)
        {
        }

        /// <summary>
        /// Gets the total row count.
        /// </summary>
        public virtual int RowCount => this.GridPattern.Current.RowCount;

        /// <summary>
        /// Gets the total column count.
        /// </summary>
        public int ColumnCount => this.GridPattern.Current.ColumnCount;

        public GridViewHeaderRowPresenter ColumnHeadersPresenter => (GridViewHeaderRowPresenter)this.FindFirstChild(Condition.GridViewHeaderRowPresenter);

        /// <summary>
        /// Gets all column header elements.
        /// </summary>
        public IReadOnlyList<GridViewColumnHeader> ColumnHeaders
        {
            get
            {
                if (this.TryFindFirst(TreeScope.Children, Condition.Header, FromAutomationElement, Retry.Time, out var header))
                {
                    return header.FindAllChildren(
                        Condition.HeaderItem,
                        x => new GridViewColumnHeader(x));
                }

                if (this.AutomationElement.TryGetTablePattern(out var tablePattern))
                {
                    return tablePattern.Current
                                       .GetColumnHeaders()
                                       .Select(x => new GridViewColumnHeader(x))
                                       .ToArray();
                }

                throw new InvalidOperationException("Could not find ColumnHeaders");
            }
        }

        /// <summary>
        /// Returns the rows which are currently visible to Interop.UIAutomationClient. Might not be the full list (eg. in virtualized lists)!
        /// Use <see cref="GetRowByIndex" /> to make sure to get the correct row.
        /// </summary>
        public virtual IReadOnlyList<ListViewItem> Rows
        {
            get
            {
                var rowCount = this.RowCount;
                var rows = new ListViewItem[rowCount];
                var gridPattern = this.AutomationElement.GridPattern();
                for (var i = 0; i < rowCount; i++)
                {
                    rows[i] = (ListViewItem)FromAutomationElement(gridPattern.GetItem(i, 0).Parent());
                }

                return rows;
            }
        }

        /// <summary>
        /// Gets all selected items.
        /// </summary>
        public IReadOnlyList<UiElement> SelectedItems => this.SelectionPattern
                                                             .Current
                                                             .GetSelection()
                                                             .Select(FromAutomationElement)
                                                             .ToArray();

        /// <summary>
        /// Gets the first selected item or null otherwise.
        /// </summary>
        public UiElement SelectedItem => this.SelectedItems?.FirstOrDefault();

        public GridPattern GridPattern => this.AutomationElement.GridPattern();

        public TablePattern TablePattern => this.AutomationElement.TablePattern();

        public GridViewCell this[int row, int col] => GridViewCell.Create(FromAutomationElement(this.GridPattern.GetItem(row, col)));

        /// <summary>
        /// Select a row by index.
        /// </summary>
        public ListViewItem Select(int rowIndex)
        {
            var gridRow = this.GetRowByIndex(rowIndex);
            if (WindowsVersion.IsWindows7())
            {
                gridRow.Cells[0].Click();
            }
            else
            {
                gridRow.Select();
            }

            return gridRow;
        }

        public ListViewItem Row(int row) => (ListViewItem)FromAutomationElement(this.GridPattern.GetItem(row, 0).Parent());

        /// <summary>
        /// Select the first row by text in the given column.
        /// </summary>
        public ListViewItem Select(int columnIndex, string textToFind)
        {
            var gridRow = this.GetRowByValue(columnIndex, textToFind);
            if (WindowsVersion.IsWindows7())
            {
                gridRow.Cells[0].Click();
            }
            else
            {
                gridRow.Select();
            }

            return gridRow;
        }

        /// <summary>
        /// Get a row by index.
        /// </summary>
        public ListViewItem GetRowByIndex(int rowIndex)
        {
            this.PreCheckRow(rowIndex);
            return (ListViewItem)FromAutomationElement(this.GridPattern.GetItem(rowIndex, 0).Parent());
        }

        /// <summary>
        /// Get a row by text in the given column.
        /// </summary>
        public ListViewItem GetRowByValue(int columnIndex, string value)
        {
            return this.GetRowsByValue(columnIndex, value, 1).FirstOrDefault();
        }

        /// <summary>
        /// Get all rows where the value of the given column matches the given value.
        /// </summary>
        /// <param name="columnIndex">The column index to check.</param>
        /// <param name="value">The value to check.</param>
        /// <param name="maxItems">Maximum numbers of items to return, 0 for all.</param>
        /// <returns>List of found rows.</returns>
        public IReadOnlyList<ListViewItem> GetRowsByValue(int columnIndex, string value, int maxItems = 0)
        {
            this.PreCheckColumn(columnIndex);
            var gridPattern = this.GridPattern;
            var returnList = new List<ListViewItem>();
            for (var rowIndex = 0; rowIndex < this.RowCount; rowIndex++)
            {
                var currentCell = gridPattern.GetItem(rowIndex, columnIndex);
                if (currentCell.Name() == value ||
                    (currentCell.TryGetValuePattern(out var valuePattern) &&
                    valuePattern.Current.Value == value))
                {
                    returnList.Add((ListViewItem)FromAutomationElement(currentCell.Parent()));
                    if (maxItems > 0 && returnList.Count >= maxItems)
                    {
                        break;
                    }
                }
            }

            return returnList.ToArray();
        }

        private void PreCheckRow(int rowIndex)
        {
            if (this.RowCount <= rowIndex)
            {
                throw new Exception($"GridView contains only {this.RowCount} row(s) but index {rowIndex} was requested");
            }
        }

        private void PreCheckColumn(int columnIndex)
        {
            if (this.ColumnCount <= columnIndex)
            {
                throw new Exception($"GridView contains only {this.ColumnCount} columns(s) but index {columnIndex} was requested");
            }
        }
    }
}
