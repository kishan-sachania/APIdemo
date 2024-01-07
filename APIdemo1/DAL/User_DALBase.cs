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
                        userModelS.PersonID = Convert.ToInt32(reader["PersonID"]);
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
                        userModel.Contact = dr["Contect"].ToString();
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

        public bool DeleteById(int PersonID)
        {

            try
            {
                SqlDatabase sqldatabase = new SqlDatabase(ConString);
                DbCommand dbCommand = sqldatabase.GetStoredProcCommand("PR_DELETE_USER");
                sqldatabase.AddInParameter(dbCommand, "@PersonID", SqlDbType.Int, PersonID);

                if (Convert.ToBoolean(sqldatabase.ExecuteNonQuery(dbCommand)))
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

                SqlDatabase sqlDatabase = new SqlDatabase(ConString);
                DbCommand dbCommand = sqlDatabase.GetStoredProcCommand("PR_INSERT_USER");
                sqlDatabase.AddInParameter(dbCommand, "@Name", SqlDbType.VarChar, userModel.Name);
                sqlDatabase.AddInParameter(dbCommand, "@Email", SqlDbType.VarChar, userModel.Email);
                sqlDatabase.AddInParameter(dbCommand, "@Contect", SqlDbType.VarChar, userModel.Contact);
                UserModel personModel = new UserModel();
                if (Convert.ToBoolean(sqlDatabase.ExecuteNonQuery(dbCommand)))
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

        public bool API_Person_Update(UserModel userModel)
        {
            try
            {
                SqlDatabase sqldb = new SqlDatabase(ConString);
                DbCommand cmd = sqldb.GetStoredProcCommand("PR_UPDATE_USER");
                sqldb.AddInParameter(cmd, "@Person", SqlDbType.Int, userModel.PersonID);
                sqldb.AddInParameter(cmd, "@Name", SqlDbType.VarChar, userModel.Name);
                sqldb.AddInParameter(cmd, "@Contect", SqlDbType.VarChar, userModel.Contact);
                sqldb.AddInParameter(cmd, "@Email", SqlDbType.VarChar, userModel.Email);

                if (Convert.ToBoolean(sqldb.ExecuteNonQuery(cmd)))
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
