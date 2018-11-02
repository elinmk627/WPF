namespace CommandExam {
    class Emp {
        public string Ename { get; set; }
        public string Job { get; set; }
        public string info {
            get {
                return Ename+", "+ Job;
            }
        }
    }
}
