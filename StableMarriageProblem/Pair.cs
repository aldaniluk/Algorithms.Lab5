namespace StableMarriageProblem
{
    public class Pair
    {
        public int Man { get; set; }
        public int Woman { get; set; }
        public int Response { get; set; }

        public Pair(int man, int woman, int response)
        {
            Man = man;
            Woman = woman;
            Response = response;
        }
    }
}
