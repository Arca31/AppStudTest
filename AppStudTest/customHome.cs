using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppStudTest
{
    class customHome:ContentPage
    {
        public customHome(RootObject Contacts) {
            Title = "RockStars";
            StackLayout layout = new StackLayout();
            var table = new TableView();
            table.Intent = TableIntent.Form;
            table.RowHeight = 65;

            SearchBar search=new SearchBar();
            table.Root = new TableRoot();

            TableSection tableselect= new TableSection("rockstars")
            {

         

                            new ViewCell() {
                                View = new Layout_home(Contacts,0),
                                            },
                            new ViewCell() {
                                View = new Layout_home(Contacts,1),
                                            },
                            new ViewCell() {
                                View = new Layout_home(Contacts,2),
                                            },
                            new ViewCell() {
                                View = new Layout_home(Contacts,3),
                                            },
                            new ViewCell() {
                                View = new Layout_home(Contacts,4),
                                            },
                            new ViewCell() {
                                View = new Layout_home(Contacts,5),
                                            }

            };
            layout.Children.Add(search);
            table.Root.Add(tableselect);
            layout.Children.Add(table);
            search.TextChanged += (sender,e) =>
            {

                if (search.Text != null)
                {
                    tableselect.Clear();
                    for (int i = 0; i < Contacts.contacts.Count; i++)
                    {
                        if (Contacts.contacts[i].fullname().ToLower().Contains(search.Text))
                        {
                            tableselect.Add(new ViewCell()
                            {
                                View = new Layout_home(Contacts, i)
                            });
                        }
                    }
                }
                else
                {
                    tableselect = new TableSection("rockstars")
                                {

                                new ViewCell() {
                                    View = new Layout_home(Contacts,0),
                                                },
                                new ViewCell() {
                                    View = new Layout_home(Contacts,1),
                                                },
                                new ViewCell() {
                                    View = new Layout_home(Contacts,2),
                                                },
                                new ViewCell() {
                                    View = new Layout_home(Contacts,3),
                                                },
                                new ViewCell() {
                                    View = new Layout_home(Contacts,4),
                                                },
                                new ViewCell() {
                                    View = new Layout_home(Contacts,5),
                                                }
                                };
                    }
                
                
            };
            

                    this.Content = layout;
           
        }


    }
}
