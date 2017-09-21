using System.Collections.Generic;
using System.ComponentModel;


namespace MotorolaTest
{
    /// <summary>
    /// ListBox edit/selection mode status settings
    /// </summary>
    public enum SelectMode
    {
        Normal,
        Edit,
        MultiSelect
    }


    /// <summary>
    /// View model for the main window
    /// </summary>
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        public MainWindowViewModel()
        {
            PropertyChanged += OnPropertyChanged;

            ListCollection.Add(new Model(true, "Item 1"));
            ListCollection.Add(new Model(true, "Item 2"));

            SelectionMode = SelectMode.Normal;
        }


        private SelectMode _selectionMode;
        /// <summary>
        /// Edit/selection state of the list box
        /// </summary>
        public SelectMode SelectionMode
        {
            get => _selectionMode;
            set
            {
                _selectionMode = value;
                if (_selectionMode == SelectMode.Normal)
                {
                    IsMultiSelect = false;
                    foreach(Model mod in ListCollection)
                    {
                        mod.IsItemReadOnly = true;
                    }
                }
                else if (_selectionMode == SelectMode.MultiSelect)
                {
                    IsMultiSelect = true;
                    foreach (Model mod in ListCollection)
                    {
                        mod.IsItemReadOnly = true;
                    }
                }
                else
                {
                    IsMultiSelect = false;
                    foreach(Model mod in ListCollection)
                    {
                        mod.IsItemReadOnly = false;
                    }
                }

                PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectionMode)));
            }
        }

        private bool _isMultiSelect;
        /// <summary>
        /// Boolean indicator whether or not the list box is in multi-select mode
        /// </summary>
        public bool IsMultiSelect
        {
            get => _isMultiSelect;
            set
            {
                _isMultiSelect = value;
                PropertyChanged(this, new PropertyChangedEventArgs(nameof(IsMultiSelect)));
            }
        }

        private ItemsList _listCollection;
        /// <summary>
        /// Collection of items to display in the list box
        /// </summary>
        public ItemsList ListCollection
        {
            get
            {
                if (_listCollection == null)
                {
                    _listCollection = new ItemsList();
                }

                return _listCollection;
            }
            set
            {
                _listCollection = value;
            }
        }

        private IList<Model> _selections;
        /// <summary>
        /// collection of list box selections, in string form, to display on the UI
        /// </summary>
        public IList<Model> Selections
        {
            get
            {
                if (_selections == null)
                {
                    _selections = new List<Model>();
                }

                return _selections;
            }
            set
            {
                _selections = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Selections)));
            }
        }


        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }
}
