using APIdemo1.DAL;
using APIdemo1.Models;

namespace APIdemo1.BAL
{
    public class User_BALBase
    {
        public List<UserModel> Selectall()
        {
            try
            {
                User_DALBase dal=new User_DALBase();
                List<UserModel> userModels = dal.Selectall();
                return userModels;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UserModel SellectByID(int PersonID)
        {
            try
            {
                User_DALBase dal = new User_DALBase();
                UserModel userModel = dal.SellectByID(PersonID);   
                return userModel;
            }
            catch (Exception ex) {
                return null;
            }
        }

        public bool DeleteById(int userid)
        {
            try
            {
                User_DALBase dal = new User_DALBase();
                if (dal.DeleteById(userid))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }

}
