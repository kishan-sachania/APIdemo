using APIdemo1.Models;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Data;
using System.Data.Common;

namespace APIdemo1.DAL
{
    public class User_DALBase : DAL_Helpers
    {
        public List<UserModel> Selectall()
        {
            try
            {
                SqlDatabase sqldatabase = new SqlDatabase(ConString);
                DbCommand dbCommand = sqldatabase.GetStoredProcCommand("PR_SELECT_ALL_USER");
                List<UserModel> userModel= new List<UserModel>();
                using (IDataReader reader = sqldatabase.ExecuteReader(dbCommand)) { 
                    while(reader.Read())            
                    {
                        UserModel userModelS= new UserModel();  
                        userModelS.Name = reader["Name"].ToString();
                        userModelS.Contact = reader["Contect"].ToString();
                        userModelS.Email = reader["Email"].ToString();
                        userModel.Add(userModelS);
                    }
                }
                return userModel;
                
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
                SqlDatabase sqlDatabase = new SqlDatabase(ConString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_SELECT_BY_PK_USER");
                sqlDatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);
                UserModel userModel = new UserModel();
                using (IDataReader dr = sqlDatabase.ExecuteReader(dbCommand))
                {
                    while (dr.Read())
                    {
                        userModel.PersonID = Convert.ToInt32(dr["PersonID"].ToString());
                        userModel.Name = dr["Name"].ToString();
                        userModel.Contact = dr["Contact"].ToString();
                        userModel.Email = dr["Email"].ToString();
                    }
                }

                return userModel;

            }

            catch (Exception ex)
            {

                return null;
            }
        }

        public bool DeleteById(int userid)
        {

            try
            {
                SqlDatabase sqldatabase = new SqlDatabase(ConString);
                DbCommand dbCommand = sqldatabase.GetSqlStringCommand("PR_DELETE_USER");
                sqldatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, userid);

                if (Convert.ToBoolean(dbCommand.ExecuteNonQuery()))
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
