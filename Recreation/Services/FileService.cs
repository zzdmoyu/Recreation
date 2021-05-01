using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using ViewDemo.Models;

namespace ViewDemo.Services
{
    public class FileService
    {
        List<DirStructureInfo> list = new List<DirStructureInfo>();
        DirStructureInfo info = new DirStructureInfo();
        public List<DirStructureInfo> GetPath(string path, int level)
        {
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fil = dir.GetFiles();
            DirectoryInfo[] dii = dir.GetDirectories();
            foreach (FileInfo f in fil)
            {
                info = new DirStructureInfo();
                info.ExistSubSet = false;
                info.ParentSetNo = level;
                info.ParentSetName = path;
                info.AllPath = f.FullName;
                info.Title = f.Name;
                list.Add(info);
            }
            level++;
            foreach (DirectoryInfo d in dii)
            {
                GetPath(d.FullName, level);
                info = new DirStructureInfo();
                info.ExistSubSet = true;
                info.ParentSetNo = level;
                info.ParentSetName = path;
                info.AllPath = d.FullName;
                info.Title = d.Name;
                list.Add(info);
            }
            return list;
        }
    }
}