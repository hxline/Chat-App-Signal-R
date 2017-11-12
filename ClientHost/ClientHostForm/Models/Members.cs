namespace ClientHostForm.Models
{
    class Members
    {
        //public string id {get; set;}
        //public string username {get; set;}

        private string _name;
        private string _id;
        private string username;
        private string id1;

        public Members(string name, string id)
        {
        _name = name;
        _id = id;
        }

        public override string ToString()
        { return _name; }

        public string id
        {
            get { return _id; }
        }

        public string name
        {
            get { return _name; }
        }

    }
}
