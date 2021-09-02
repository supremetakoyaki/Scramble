using System.Windows.Forms;

namespace Scramble.Util
{
    public static class ColumnSorter
    {
        private static ColumnHeader SortingColumn = null;

        public static void Sort(ListView listView, ColumnClickEventArgs e)
        {
            ColumnHeader NewSortingColumn = listView.Columns[e.Column];

            SortOrder Order;
            if (SortingColumn == null)
            {
                Order = SortOrder.Ascending;
            }
            else
            {
                if (NewSortingColumn == SortingColumn)
                {
                    if (SortingColumn.Text.StartsWith("> "))
                    {
                        Order = SortOrder.Descending;
                    }
                    else
                    {
                        Order = SortOrder.Ascending;
                    }
                }
                else
                {
                    Order = SortOrder.Ascending;
                }

                SortingColumn.Text = SortingColumn.Text.Substring(2);
            }

            SortingColumn = NewSortingColumn;
            if (Order == SortOrder.Ascending)
            {
                SortingColumn.Text = "> " + SortingColumn.Text;
            }
            else
            {
                SortingColumn.Text = "< " + SortingColumn.Text;
            }

            listView.ListViewItemSorter = new ListViewComparer(e.Column, Order);
            listView.Sort();
        }
    }
}
