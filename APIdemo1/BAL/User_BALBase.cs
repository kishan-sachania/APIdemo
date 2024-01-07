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

        public bool DeleteById(int PersonID)
        {
            try
            {
                User_DALBase dal = new User_DALBase();
                if (dal.DeleteById(PersonID))
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

        public bool API_PR_INSERT_USER(UserModel userModel)
        {
            try
            {
                User_DALBase person_DALBase = new User_DALBase();
                if (person_DALBase.API_PR_INSERT_USER(userModel))
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }

        public bool API_Person_Update(UserModel userModel)
        {
            try
            {
                User_DALBase dalperson = new User_DALBase();
                if (dalperson.API_Person_Update(userModel))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

    }

}
