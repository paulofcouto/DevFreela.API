namespace DevFreela.Core.Entities
{
    public class UserSkill : BaseEntity
    {
        public UserSkill(int idUser, int idSkill) 
        {
            idUser = IdUser;
            idSkill = IdSkill;
        }
        public int IdUser { get; private set; }
        public int IdSkill { get; private set; }
    }
}