namespace CF_16KI_16J_KO_CI.Modeles
{
    public class ClubNombre
    {
        public string sClub { get; set; }
        public int iNombre { get; set; }

        public ClubNombre(string _sClub)
        {
            sClub = _sClub;
            iNombre = 0;
        }
    }
}
