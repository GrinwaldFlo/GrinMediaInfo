using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrinMediaInfo
{
	public class BindingData : CollectionBase, IBindingList, IList<clData>
	{

		private ListChangedEventArgs resetEvent = new ListChangedEventArgs(ListChangedType.Reset, -1);
		private ListChangedEventHandler onListChanged;


		public clData this[int index]
		{
			get
			{
				return (clData)(List[index]);
			}
			set
			{
				List[index] = value;
			}
		}

		public int Add(clData value)
		{
			return List.Add(value);
		}

		public clData AddNew()
		{
			return (clData)((IBindingList)this).AddNew();
		}

		public void Remove(clData value)
		{
			List.Remove(value);
		}

		protected virtual void OnListChanged(ListChangedEventArgs ev)
		{
			if (onListChanged != null)
			{
				onListChanged(this, ev);
			}
		}

		protected override void OnClear()
		{
			foreach (clData c in List)
			{
				c.Parent = null;
			}
		}

		protected override void OnClearComplete()
		{
			OnListChanged(resetEvent);
		}

		protected override void OnInsertComplete(int index, object value)
		{
			clData c = (clData)value;
			c.Parent = this;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
		}

		protected override void OnRemoveComplete(int index, object value)
		{
			clData c = (clData)value;
			c.Parent = this;
			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemDeleted, index));
		}

		protected override void OnSetComplete(int index, object oldValue, object newValue)
		{
			if (oldValue != newValue)
			{

				clData oldcust = (clData)oldValue;
				clData newcust = (clData)newValue;

				oldcust.Parent = null;
				newcust.Parent = this;

				OnListChanged(new ListChangedEventArgs(ListChangedType.ItemAdded, index));
			}
		}

		// Called by Customer when it changes.
		internal void DataChanged(clData cust)
		{
			int index = List.IndexOf(cust);

			OnListChanged(new ListChangedEventArgs(ListChangedType.ItemChanged, index));
		}

		// Implements IBindingList.
		bool IBindingList.AllowEdit
		{
			get { return true; }
		}

		bool IBindingList.AllowNew
		{
			get { return true; }
		}

		bool IBindingList.AllowRemove
		{
			get { return true; }
		}

		bool IBindingList.SupportsChangeNotification
		{
			get { return true; }
		}

		bool IBindingList.SupportsSearching
		{
			get { return false; }
		}

		bool IBindingList.SupportsSorting
		{
			get { return true; }
		}

		// Events.
		public event ListChangedEventHandler ListChanged
		{
			add
			{
				onListChanged += value;
			}
			remove
			{
				onListChanged -= value;
			}
		}

		// Methods.
		object IBindingList.AddNew()
		{
			throw new NotSupportedException();
		}

		bool _IsSorted = false;
		bool IBindingList.IsSorted
		{
			get { return _IsSorted; }
		}

		ListSortDirection _SortDirection = ListSortDirection.Ascending;
		ListSortDirection IBindingList.SortDirection
		{
			get { return _SortDirection; }
		}

		PropertyDescriptor _SortProperty;
		PropertyDescriptor IBindingList.SortProperty
		{
			get { return _SortProperty; }
		}

		public bool IsReadOnly => throw new NotImplementedException();

		// Unsupported Methods.
		void IBindingList.AddIndex(PropertyDescriptor property)
		{
			throw new NotSupportedException();
		}

		void IBindingList.ApplySort(PropertyDescriptor property, ListSortDirection direction)
		{
			this._SortProperty = property;
			this._SortDirection = direction;

			List<clData> items = null;

			if (direction == ListSortDirection.Ascending)
			{
				switch (property.Name)
				{
					case "Bitrate":
						items = this.OrderBy(X => X.Bitrate).ToList();
						break;
					case "Path":
						items = this.OrderBy(X => X.Path).ToList();
						break;
					case "Duration":
						items = this.OrderBy(X => X.durationMs).ToList();
						break;
					case "SizeMb":
						items = this.OrderBy(X => X.SizeMb).ToList();
						break;
					case "Format":
						items = this.OrderBy(X => X.Format).ToList();
						break;
					case "Status":
						items = this.OrderBy(X => X.Status).ToList();
						break;
					default:
						break;
				}
			}
			else
			{
				switch (property.Name)
				{
					case "Bitrate":
						items = this.OrderByDescending(X => X.Bitrate).ToList();
						break;
					case "Path":
						items = this.OrderByDescending(X => X.Path).ToList();
						break;
					case "Duration":
						items = this.OrderByDescending(X => X.durationMs).ToList();
						break;
					case "SizeMb":
						items = this.OrderByDescending(X => X.SizeMb).ToList();
						break;
					case "Format":
						items = this.OrderByDescending(X => X.Format).ToList();
						break;
					case "Status":
						items = this.OrderByDescending(X => X.Status).ToList();
						break;
					default:
						break;
				}
			}

			this.List.Clear();
			foreach (var item in items)
			{
				this.List.Add(item);
			}

			_IsSorted = true;
			OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, property));




		}

		int IBindingList.Find(PropertyDescriptor property, object key)
		{
			throw new NotSupportedException();
		}

		void IBindingList.RemoveIndex(PropertyDescriptor property)
		{
			throw new NotSupportedException();
		}

		void IBindingList.RemoveSort()
		{
			throw new NotSupportedException();
		}

		public int IndexOf(clData item)
		{
			throw new NotImplementedException();
		}

		public void Insert(int index, clData item)
		{
			throw new NotImplementedException();
		}

		void ICollection<clData>.Add(clData item)
		{
			throw new NotImplementedException();
		}

		public bool Contains(clData item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(clData[] array, int arrayIndex)
		{
			this.List.CopyTo(array, arrayIndex);
		}

		bool ICollection<clData>.Remove(clData item)
		{
			throw new NotImplementedException();
		}

		IEnumerator<clData> IEnumerable<clData>.GetEnumerator()
		{
			throw new NotImplementedException();
		}
	}
}
