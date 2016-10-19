using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStudTest
{
    class customBookmarks:ContentPage
    {
        public customBookmarks(RootObject Contacts) {
            Title = "BookMarks";
            var table = new TableView();
            table.Intent = TableIntent.Menu;
            table.RowHeight = 65;

            table.Root = new TableRoot();

            TableSection tableselection=new TableSection("bookmarks");

            table.Root.Add(tableselection);

            if (Application.Current.Properties.ContainsKey("0"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 0),
                });
            }

            if (Application.Current.Properties.ContainsKey("1"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 1),
                });
            }

            if (Application.Current.Properties.ContainsKey("2"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 2),
                });
            }

            if (Application.Current.Properties.ContainsKey("3"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 3),
                });
            }

            if (Application.Current.Properties.ContainsKey("4"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 4),
                });
            }

            if (Application.Current.Properties.ContainsKey("5"))
            {
                tableselection.Add(new ViewCell
                {
                    View = new Layout_bookmark(Contacts, 5),
                });
            }

            this.Content = table;
        }
        
    }
}
