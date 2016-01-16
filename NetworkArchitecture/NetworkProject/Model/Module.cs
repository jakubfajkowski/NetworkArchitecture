namespace NetworkArchitecture.NetworkProject.Model
{
    class Module
    {
        private double capacity;
        public double Capacity
        {
            get { return capacity; }
        }

        private double price;
        public double Price
        {
            get { return price; }
        }

        public Module(double weight, double price)
        {
            this.capacity = weight;
            this.price = price;
        }
    }
}
