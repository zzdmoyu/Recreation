using Recreation.DataAccess;
using Recreation.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Recreation.Services
{
    public class StoryService
    {
        public void Insert(Story info)
        {
            SqlHelper sqlHelp = new SqlHelper();
            string excuteSql = string.Format(@"INSERT INTO  Recreation.story 
                                              (StoryId,Title,SubTitle,IndexSort,StoryType,CreateDate,UpdateDate,
                                              Content,IsDelete) VALUES ( '{0}','{1}','{2}', {3}, {4}, '{5}','{6}','{7}',0);",
                                            info.StoryId, info.Title, info.SubTitle, info.IndexSort,
                                            info.StoryType, info.CreateDate, info.UpdateDate, info.Content);
            sqlHelp.ExecuteNonQuery(excuteSql);
        }

        public List<Story> GetModelList(int startIndex,int endIndex)
        {
            string sqlstr = string.Format("select * from Recreation.story Limit {0},{1};", startIndex, endIndex);
            DataTable dataTable = new SqlHelper().GetDataTable(sqlstr);
            var list = GetStoryView(dataTable);
            return list;
        }

        public int GetCount()
        {
            string sqlstr = "select Count(*) from Recreation.story;";
            DataTable dataTable = new SqlHelper().GetDataTable(sqlstr);
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
               return int.Parse(dataTable.Rows[0][0].ToString());
            }
            return 0;
        }

        internal List<Story> GetList()
        {
            string sqlstr = "select * from Recreation.story;";
            DataTable dataTable = new SqlHelper().GetDataTable(sqlstr);
            var list = GetStoryView(dataTable);
            return list;
        }

        internal void Update(Story info)
        {
            SqlHelper sqlHelp = new SqlHelper();
            string excuteSql = string.Format(@"UPDATE  Recreation.story Set Title = '{1}',SubTitle = '{2}',
                                               IndexSort={3},StoryType={4},UpdateDate='{5}',Content= '{6}'
                                               WHERE StoryId = '{0}';",
                                            info.StoryId, info.Title, info.SubTitle, info.IndexSort,
                                            info.StoryType,  info.UpdateDate, info.Content);
            sqlHelp.ExecuteNonQuery(excuteSql);
        }

        internal Story GetListById(string id)
        {
            string sqlstr = string.Format("select * from Recreation.story where storyId = '{0}';", id);
            DataTable dataTable = new SqlHelper().GetDataTable(sqlstr);
            var list = GetStoryView(dataTable);
            return list.FirstOrDefault();
        }

        private List<Story> GetStoryView(DataTable dataTable)
        {
            List<Story> list = new List<Story>();
            if ((dataTable != null) && (dataTable.Rows.Count > 0))
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    Story item = new Story
                    {
                        StoryId = (dataTable.Rows[i]["StoryId"] != null) ? dataTable.Rows[i]["StoryId"].ToString() : "",
                        Title = (dataTable.Rows[i]["Title"] != null) ? dataTable.Rows[i]["Title"].ToString() : "",
                        SubTitle = (dataTable.Rows[i]["Subtitle"] != null) ? dataTable.Rows[i]["Subtitle"].ToString() : "",
                        IndexSort = (dataTable.Rows[i]["IndexSort"] != null) ? int.Parse(dataTable.Rows[i]["IndexSort"].ToString()) : 0,
                        StoryType = (dataTable.Rows[i]["StoryType"] != null) ? int.Parse(dataTable.Rows[i]["StoryType"].ToString()) : 0,
                        IsDelete = (dataTable.Rows[i]["IsDelete"] != null) ? int.Parse(dataTable.Rows[i]["IsDelete"].ToString()) : 0,
                        UpdateDate = (dataTable.Rows[i]["UpdateDate"] != null) ? DateTime.Parse(dataTable.Rows[i]["UpdateDate"].ToString()) : DateTime.Now,
                        CreateDate = (dataTable.Rows[i]["CreateDate"] != null) ? DateTime.Parse(dataTable.Rows[i]["CreateDate"].ToString()) : DateTime.Now,
                        Content = (dataTable.Rows[i]["Content"] != null) ? dataTable.Rows[i]["Content"].ToString() : ""
                    };
                    list.Add(item);
                }
            }
            return list;
        }

    }
}