using System;

namespace EntityCache.ViewModels
{
    public class OrderItem
    {
        public Guid PrdGuid { get; set; }
        public int Count { get; set; }
    }
    public class OrderItemViewModel
    {
        public Guid PrdGuid { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
    }
    public class ShowOrderViewModel
    {
        public Guid PrdGuid { get; set; }
        public string Title { get; set; }
        public string ImageName { get; set; }
        public int Count { get; set; }
        public decimal Price { get; set; }
        public decimal Sum { get; set; }
    }
}
