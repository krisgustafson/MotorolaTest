using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;


namespace MotorolaTest
{
    /// <summary>
    /// Class derived from ObservableCollection to hold "Model" objects
    /// </summary>
    public class ItemsList : ObservableCollection<Model>
    {
        public ItemsList() : base()
        {
            CollectionChanged += ItemsList_CollectionChanged;
        }

        private void ItemsList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                ((Model)e.NewItems[0]).PropertyChanged += Item_PropertyChanged;
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                ((Model)e.OldItems[0]).PropertyChanged -= Item_PropertyChanged;
            }
        }

        private void Item_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
        }
    }


    /// <summary>
    /// Data class ("model") for items to display on the UI
    /// </summary>
    public class Model : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Model(bool state, string item)
        {
            IsItemReadOnly = state;
            Item = item;
        }

        private bool _isItemReadOnly;
        /// <summary>
        /// Flag indicating if this Model is read-only
        /// </summary>
        public bool IsItemReadOnly
        {
            get => _isItemReadOnly;
            set
            {
                if (_isItemReadOnly != value)
                {
                    _isItemReadOnly = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsItemReadOnly)));
                }
            }
        }

        private string _item;
        /// <summary>
        /// Data to display on the UI
        /// </summary>
        public string Item
        {
            get => _item;
            set
            {
                if (_item != value)
                {
                    _item = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Item)));
                }
            }
        }

        /// <summary>
        /// Equals override - necessary for removing 'Model' objects from the observable list
        /// </summary>
        /// <param name="obj">object to compare to this Model</param>
        /// <returns>true if equal; false if not</returns>
        public override bool Equals(object obj)
        {
            if (obj is Model == false)
            {
                return false;
            }

            return this.Item == ((Model)obj).Item;
        }

        /// <summary>
        /// Since the Equals method was overridden, this hash code method ought to be overridden, too.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
