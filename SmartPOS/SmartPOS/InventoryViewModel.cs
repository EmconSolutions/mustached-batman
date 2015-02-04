using System;
using System.Collections.ObjectModel;
using System.Linq;
using SmartPOS.Core.Inventory;

namespace SmartPOS
{
    public class InventoryViewModel
    {
        private readonly InventoryClient _inventoryClient;
        private readonly string _someFancyUniqueId;

        public InventoryViewModel()
        {
            Items = new ObservableCollection<InventoryItem>();
            _inventoryClient = new InventoryClient();
            _someFancyUniqueId = Guid.NewGuid().ToString(); //that's not unique.
        }

        /// <summary>
        ///     The current list of items.
        /// </summary>
        /// <remarks>
        ///     Do not modify this collection directly, use the methods dog!
        /// </remarks>
        public ObservableCollection<InventoryItem> Items { get; set; }

        public async void AddItem(string ean)
        {
            var item = await _inventoryClient.AddItem(_someFancyUniqueId, ean);
            var currentItem = Items.SingleOrDefault(x => x.Ean == item.Ean);
            if (currentItem == null)
                Items.Add(new InventoryItem {Ean = item.Ean, Quantity = item.Quantity, Text = item.Text});
            else
            {
                currentItem.Quantity = item.Quantity;
            }
        }

        public async void RemoveItem(string ean)
        {
            await _inventoryClient.RemoveItem(_someFancyUniqueId, ean);
            Items.Remove(Items.Single(x => x.Ean == ean));
        }
    }
}