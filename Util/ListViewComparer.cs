using System;
using System.Collections;
using System.Windows.Forms;

namespace Scramble.Util
{
    internal class ListViewComparer : IComparer
    {
        private readonly int ColumnNumber;
        private readonly SortOrder SortOrder;

        public ListViewComparer(int column_number,
            SortOrder sort_order)
        {
            ColumnNumber = column_number;
            SortOrder = sort_order;
        }

        public int Compare(object object_x, object object_y)
        {
            ListViewItem item_x = object_x as ListViewItem;
            ListViewItem item_y = object_y as ListViewItem;

            string string_x;
            if (item_x.SubItems.Count <= ColumnNumber)
            {
                string_x = "";
            }
            else
            {
                string_x = item_x.SubItems[ColumnNumber].Text;
            }

            string string_y;
            if (item_y.SubItems.Count <= ColumnNumber)
            {
                string_y = "";
            }
            else
            {
                string_y = item_y.SubItems[ColumnNumber].Text;
            }

            int result;
            if (double.TryParse(string_x, out double double_x) &&
                double.TryParse(string_y, out double double_y))
            {
                result = double_x.CompareTo(double_y);
            }
            else
            {
                if (DateTime.TryParse(string_x, out DateTime date_x) &&
                    DateTime.TryParse(string_y, out DateTime date_y))
                {
                    result = date_x.CompareTo(date_y);
                }
                else
                {
                    result = string_x.CompareTo(string_y);
                }
            }

            if (SortOrder == SortOrder.Ascending)
            {
                return result;
            }
            else
            {
                return -result;
            }
        }
    }
}
