using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;
using System.Text;
namespace sign_Online
{
    public class Dboperation
    {
        //链接数据库对象
        SqlConnection sqlcon = null;
        //链接字符串
        String constr = "server=better;uid=sa;pwd=sa123456;database=sign_Online";
        //  String str = "Server=BETTER;Initial CataLog=DataBaseName;Uid=sa;pwd=sa123456";
        String filedirectorypath = "F:\\Sign_online\\userfile\\";
        //协议模板文件夹
        String protocelmould="protocelmould";
        //用户协议文件夹
        String protocels="protocels";
        //用户头像文件夹
        String usericon="usericon";
        //用户反馈文件夹
        String usersuggestion = "usersuggestion";
        //需要传输的文件所在的文件夹
        String filetotranslate = "filetotranslate";
        public Dboperation()
        {
            if (sqlcon == null)
            {
                sqlcon = new SqlConnection();
                //设定链接字符串
                sqlcon.ConnectionString = constr;
                //打开链接
                sqlcon.Open();
            }
        }
        //析构方法
        public void Dispose()
        {
            if (sqlcon != null)
            {
                sqlcon.Close();
                sqlcon = null;
            }
        }

        /* 插入用户的简单信息
         * Sinsert
         * @param useremail
         * @param userpassword
         */
        public String Sinsertimportusermsg(String useremail, String userpassword)
        {
            String str = "insert usermsg (useremail,userpassword) values   ('" + useremail + "','" + userpassword + "')";
          SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
          try{
              sqlcommand.ExecuteNonQuery();
              sqlcommand.Dispose(); 
              return "ok";
          }
          catch(Exception e) {
              return e+"";
          }
         }

        /* 查询用户信息
         * Sselect
         * @param username
         */
        public List<String> Sselect(String useremail) { 
        List<String> result=new List<string>();
        String str = "select * from usermsg where useremail = " + "'" + useremail + "'";
        SqlCommand sqlcommand = new SqlCommand(str,sqlcon);
        SqlDataReader reader = sqlcommand.ExecuteReader();
        try
        {
            while (reader.Read())
            {
                result.Add(reader[0].ToString());
                result.Add(reader[1].ToString());
                result.Add(reader[2].ToString());
                result.Add(reader[3].ToString());
                result.Add(reader[4].ToString());
                result.Add(reader[5].ToString());
                result.Add(reader[6].ToString());
            }
            reader.Close();
            reader.Dispose();
            return result;
        }
        catch
        {
            return null;
        }
        }

        /* 更新用户信息
        * Supdate
         * @param username
         * @param newusername
         * @param newuserreallyname
         * @param newuseremail
         * @param newuserpassword
         * @param newuseridnumber
         * @param newusersex
        */
        public String Supdate(String useremail,String newusername, String newuserreallyname, String newphonenumber, String newusersex, String newuseryearold)
        {
            String str = "update usermsg set " + " username = " + "'" + newusername + "'" + "," + " userreallyname = " + "'" + newuserreallyname + "'" + "," + " userphonenumber =" + "'" + newphonenumber + "'" + "," + "usersex =" + "'" + newusersex + "'" + "," + " useryearold = " + "'" + newuseryearold + "'" + " where useremail = " + "'" + useremail + "'";
            SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
            try
            {
                sqlcommand.ExecuteNonQuery();
                sqlcommand.Dispose(); 
                return "ok";
            }
            catch(Exception e)
            {
                return e+"";
            }
        }


        /* 更新插入用户详细信息用户信息
        * Supdate
         * @param useremail
         * @param username
         * @param userreallyname
         * @param userphonenumber
         * @param usersex
        */
        public String Sunimportantupdate(String useremail, String username, String userreallyname,  String userphonenumber, String usersex, String useryearold)
        {
            String str = "update usermsg set " + " username = " + "'" + username + "'" + "," + " userreallyname = " + "'" + userreallyname + "'" + ","  + " userphonenumber =" + "'" + userphonenumber + "'" + "," + " usersex =" + "'" + usersex + "'" + "," + " useryearold = " + "'" + useryearold + "'" + " where useremail = " + "'" + useremail + "'";
            SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
            try
            {
                sqlcommand.ExecuteNonQuery();
                sqlcommand.Dispose();
                return "ok";
            }
            catch(Exception e)
            {
                return e+"";
            }
        }


        /* 更新某一项用户基本信息用户信息
       * Supdate
        * @param useremail（用户邮箱）
        * @param property（等待更新的属性名）
        * @param newvalue（新的值）
         */
        public String Soneupdate(String useremail, String property, String newvalue)
        {
            String str = " update usermsg set "  + property  + " = " + "'" + newvalue + "'" + "where useremail =" + "'" + useremail +"'";
            SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
            try
            {
                sqlcommand.ExecuteNonQuery();
                sqlcommand.Dispose();
                return "ok";
            }
            catch(Exception e)
            {
                return e+"";
            }
        }

        /*注销用户
        * Sdelete
        * @param username
        */
        public bool Sdelete(String username)
        {
            String str = "delete from usermsg where username = " + "'" + username + "'"+ " where usermail =" + "'" + username + "'";
            SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
            try
            {
                sqlcommand.ExecuteNonQuery();
                sqlcommand.Dispose();
                return true;
                
            }
            catch
            {
                return false;
            }
        }


        /*对广告轮转图表查询操作，用户客户端获取广告url
         * Sselectpictureurl
         */
        public List<String> Sselectpictureurl() {
            List<String> list = new List<String>();
            String str = "select * from bannerpictureurl";
            SqlCommand sqlcom = new SqlCommand(str,sqlcon);
            SqlDataReader reader = sqlcom.ExecuteReader();
            while (reader.Read()) {
                list.Add(reader[0].ToString());
                list.Add(reader[1].ToString());
                list.Add(reader[2].ToString());
                list.Add(reader[3].ToString());
            }
            return list;
        }

        /*在服务器端创建相应的用户文件夹，远程提供用户信息
         * Inituserfile
         * @param useremail
         *@return bool
         */
        public bool Inituserfile(String useremail)
        {
           
            try
            {
                //创建用户相应文件夹
                if (File.Exists(filedirectorypath+useremail) == true)
                {
                    //如果用户useremail已经存在
                    return false;
                }
                else
                {
                    //用户文件夹未创建,创建用户文件
                    //协议模板
                    Directory.CreateDirectory(filedirectorypath+useremail+"\\"+protocelmould);
                    //用户协议
                    Directory.CreateDirectory(filedirectorypath + useremail + "\\" + protocels);
                    //用户头像
                    Directory.CreateDirectory(filedirectorypath + useremail + "\\" + usericon);
                    //用户建议
                    Directory.CreateDirectory(filedirectorypath + useremail + "\\" + usersuggestion);
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
      
        /*将用户的头像存在服务器相应目录
         * Saveusericon
         * @param String useremail 用户邮箱
         * @param byte usericonbyte 用户头像字节流
         */
        public bool Saveusericon(String useremail,byte[] usericonbyte) {
            try
            {
                //缓存流
                MemoryStream memorystream = new MemoryStream(usericonbyte);
                //物理文件流
                FileStream filestream = new FileStream(filedirectorypath  + useremail + "\\" + usericon + "\\" + "usericon.jpg", FileMode.Create);
                memorystream.WriteTo(filestream);
                memorystream.Close();
                filestream.Close();
                return true;
            }
            catch {
                return false;
            }


        }


          
        /*将用户的协议模板进行保存 保存成txt 其中txt名为模板名 txt内容为模板
         * Saveprotocelmould
         * @param String useremail 用户邮箱
         * @param String protocelmouldname 协议模板名
         * @param String protocelmouldcontent 协议模板体
         */
        public String Saveprotocelmould(String useremail, String protocelmouldname,String protocelmouldcontent)
        {

            String savePath = filedirectorypath + useremail + "\\" + protocelmould;
            FileInfo fileinfor = new FileInfo(savePath);
            if (!fileinfor.Exists)
            {
                fileinfor.Directory.Create();
            }
           String filepath=savePath  + "\\"+protocelmouldname + ".txt";
            try
            {
             if(!File.Exists(filepath)==true){
                 //在协议目录创建相应的模板名称
                 Directory.CreateDirectory(filedirectorypath+useremail+"\\"+protocels+"\\"+protocelmouldname);
                //输出文件流
                FileStream filestream = new FileStream(filepath,FileMode.Create,FileAccess.ReadWrite);
                StreamWriter writer = new StreamWriter(filestream);
                //写入内容
                writer.WriteLine(protocelmouldcontent);
                //关闭流 从大到小
                writer.Close();
                filestream.Close();
             }
             return "ok";
            }
            catch(Exception e){
                //写入失败
                return e+"";
            }
        }

        /*将用户的协议（图片）存在服务器相应目录
        * Saveuserprotocel
        * @param String useremail 用户邮箱
        * @param String protocelstring 用户协议图片字节流
        * @param String protocelmouldname 协议所属的模板名
         * @param String date 协议书写的日期
        */
        public String Saveuserprotocel(String useremail, String protocelmouldname, String date, String protocelstring)
        {
            try
            {
                String savePath = filedirectorypath + useremail + "\\" + protocels + "\\" + protocelmouldname;
               if (!File.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
             //   FileStream filestream = new FileStream(savePath + "\\" + date + ".jpg", FileMode.Create, FileAccess.ReadWrite);
            //    byte[] usericonbyte = System.Text.Encoding.Default.GetBytes(protocelstring);
                byte[] usericonbyte = Convert.FromBase64String(protocelstring);
              // byte[] usericonbyte = System.Text.Encoding.UTF8.GetBytes(protocelstring);
                MemoryStream memorystream = new MemoryStream(usericonbyte);
                Bitmap bitmap = new Bitmap(memorystream);
                bitmap.Save(savePath + "\\" + date + ".jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
               // filestream.Flush();
                // filestream.Close();
               // memorystream.Close();
                return "ok";
            }
            catch (Exception e){
                return ""+e;
            }
        }

        
        /*从服务器文件中读取用户的头像
         * Getusericon
         * @param useremail
         */
        public List<String> Getusericon(String useremail) {
            try
            {
                List<String> list = new List<string>();
                string pic = null;
                String filepath = filedirectorypath  + useremail + "\\" + usericon+"\\"+"usericon.jpg";
               if(!File.Exists(filepath))
                {
                    return null;
                }
                Image img = Image.FromFile(filepath);
                byte[] arr;
                using (MemoryStream ms = new MemoryStream())
                {
                    img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    arr = ms.ToArray();
                    pic = Convert.ToBase64String(arr);
                    list.Add(pic);
                    ms.Close();
                }
                return list;
            }
            catch {
                return null;
            }
        }


        /*从服务器文件中读取用户的协议模板
         * Getprotocelmould
         * @param useremail
         * return List<String>
         */
        public List<String> Getprotocelmould(String useremail) {
           
                List<String> list = new List<string>();
                try
                {
                    String filepath = filedirectorypath + useremail + "\\" + protocelmould;
                // FileStream filestream = new FileStream(filepath, FileMode.Append, FileAccess.Write);
                    String str = "";
                    //读取工具
                // StreamReader reader = new StreamReader(filestream);
                DirectoryInfo dinfo = new DirectoryInfo(filepath);
                if (dinfo.GetFiles().Length == 0)
                {
                    return list;
                }
                //获取所有文件
                FileInfo[] files = dinfo.GetFiles();
                //文件名（即协议模板名全称）
                String mouldfullname = null;
                foreach (FileInfo file in files)
                {
                    StreamReader sr = new StreamReader(file.FullName,System.Text.Encoding.UTF8); 
                    //先读取文件名
                        mouldfullname = file.Name;
                        list.Add(mouldfullname.Substring(0, mouldfullname.LastIndexOf(".")));
                        while (sr.Peek() > 0)
                        {
                            str += sr.ReadLine().ToString();
                            
                        }
                        list.Add(str);
                        str = "";
                        sr.Close();
                }
                return list;
            }
            catch {
                return list;
            }
        }

          /*从服务器文件中读取用户的协议
         * Getprotocelmould
         * @param useremail
         * @param date
         * return List<String>
         */
        public List<String> Getprotocel(String useremail)
        {
            List<String> list = new List<string>();
            try
            {
                String filepath = filedirectorypath + useremail + "\\" + protocels;
                DirectoryInfo dinfo = new DirectoryInfo(filepath);
                //获取所有子目录
                DirectoryInfo[] subdinfos = dinfo.GetDirectories();
                if (subdinfos.Length == 0) {
                    return null;
                }
                foreach (DirectoryInfo subdinfo in subdinfos)
                {

                    list.Add("1");
                    //先增加目录名（即模板名）
                    list.Add(subdinfo.Name);
                    //获取所有文件
                    FileInfo[] files = subdinfo.GetFiles();
                    foreach (FileInfo file in files)
                    {
                        if (file.Length > 0)
                        {
                            list.Add(file.Name);
                            Image image = Image.FromFile(file.FullName);
                            MemoryStream ms = new MemoryStream();
                            image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                            byte[] arr = new byte[ms.Length];
                            ms.Position = 0;
                            ms.Read(arr, 0, (int)ms.Length);
                            ms.Close();
                            string pic = Convert.ToBase64String(arr);
                            list.Add(pic);
                        }
                    }
                    list.Add("2");
                }
                return list;
            }
            catch {
                return list;
            }
        }


        /*将用户的反馈储存到本地用户文件夹
         *Saveusersuggestion
         *@String useremail  用户邮箱
         *@String usersuggestion 用户反馈
         */
        public String Saveusersuggestion(String useremail,String usersuggestioncontent) {
                 String filepath=filedirectorypath+useremail+"\\"+usersuggestion;
                 if (!File.Exists(filepath)) { 
                 //创建目录
                     Directory.CreateDirectory(filepath);
                 }
                 try
                 {
                     FileStream filestream = new FileStream(filepath+"\\"+DateTime.Now.ToFileTimeUtc().ToString().Trim()+".txt",FileMode.Create,FileAccess.ReadWrite);
                     //保存用户的反馈
                     StreamWriter writer = new StreamWriter(filestream);
                     writer.WriteLine(usersuggestioncontent);
                     //关闭流
                     writer.Close();
                     filestream.Close();
                     return "ok";
                 }
                 catch (Exception e){
                     return e+"";
                 }
        }


        /*将用户发送过来的信息进行保存，保存到服务器本地
         * Savetranslatefiletoserver
         * @param sendport 发送方
         * @param receiveport 接收方
         * @param filename 文件名
         * @param filecontent 传输的内容
         * @param remark 备注
         */
        public String Savetranslatefiletoserver(String sendport, String receiveport, String filename, String filecontent, String remark)
        {
            try {
                filename = receiveport + filename;
                String filepath = filedirectorypath + filetotranslate + "\\" + filename;
                    FileStream filestream=new FileStream(filepath,FileMode.CreateNew,FileAccess.ReadWrite);
                    StreamWriter writer = new StreamWriter(filestream);
                    writer.WriteLine(filecontent);
                    writer.Close();
                    String sqlstr = "insert userim (sendport,receiveport,filename,remark) values   ('" + sendport + "','" + receiveport + "','" + filename + "','" + remark + "')";
                    SqlCommand sqlcommand = new SqlCommand(sqlstr,sqlcon);
                    sqlcommand.ExecuteNonQuery();
                    sqlcommand.Dispose();
                return "ok";
            }
            catch(Exception e){
                return e+"";
            }

        }

        /*查询特定接收者并且没有被接收的接受信息
         * Gettranslatemsgbyrecevier
         * @param recevieport  接收方
         * @return List<String>
         */
        public List<String> Gettranslatemsgbyreceiver(String recevieport) {
            
                List<String> list=new List<String>();
            try
            {
                String sqlstr = "select filename,sendport,remark from userim where receiveport = " + "'" + recevieport + "'";
                SqlCommand sqlcommand = new SqlCommand(sqlstr,sqlcon);
                SqlDataReader reader = sqlcommand.ExecuteReader();
                while (reader.Read()) {
                    list.Add(reader[0].ToString());
                    list.Add(reader[1].ToString());
                    list.Add(reader[2].ToString());
                }
                return list ;
            }
            catch{
                return null;
            }
          }

        /*用户用户在客户端接收好友发来的文件
         * Gettranslatefilebyrecevier
         * @param receiveport 接收方名
         * @param filename 需要接收的文件名
         * @return String
         */
        public List<String> Gettranslatefilebyreceiver(String filename,String receiveport)
        {
            List<String> list = new List<string>();
            try
            {
                String result = null;
                String str = null;
                String path = filedirectorypath + filetotranslate + "\\" + receiveport + filename;
                StreamReader reader = new StreamReader(path,Encoding.Default);
                while((str=reader.ReadLine())!=null){
                    result += str;
                }
                list.Add(result);
                return list;
            }
            catch{
                return null;
            }
        }

        /*用户用户在客户端接收好友发来的文件后，删除该文件
         * Gettranslatefilebyrecevier
         * @param receiveport 接收方名
         * @param filename 需要接收的文件名
         * @return String
         */
        public String Deletetranslatefile(String filename, String receiveport)
        {
            try
            {
                String filepath = filedirectorypath + filetotranslate + "\\" + receiveport + filename;
                File.Delete(filepath);
                return "ok";
            }
            catch (Exception e)
            {
                return e + "";
            }
        }


      /*删除某个协议
       * DeleteMyProtocel
       * @param userEmail  用户邮箱
       * @param protocelMoudelName  模板名称
       * @param protocelName 用户协议名
       */
        public String DeleteMyProtocel(String userEmail,String protocelMoudelName,String protocelName){
            String filePath = filedirectorypath + userEmail + "\\" + protocels + "\\" + protocelMoudelName;
            try
            {
                if (!Directory.Exists(filePath) || ((new DirectoryInfo(filePath)).GetFiles().Length == 0))
                {
                    return "" + filePath + File.Exists(filePath) + ((new DirectoryInfo(filePath)).GetFiles().Length == 0);
                }
                FileInfo fileInfo = new FileInfo(filePath + "\\" + protocelName);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                    return "ok";
                }
                else
                {
                    return "ok2";
                }
            }
            catch(Exception e){
                return "ok3"+e;
            }
        }

        /*更新客户端banner图片的地址
         * UpdateBannerPictureUrl
         * @param banner1Url
         * @param banner2Url
         * @param banner3Url
         * @param banner4Url
         */
        public String UpdateBannerPictureUrl(String banner1Url,String banner2Url,String banner3Url,String banner4Url) {
            String str = "update bannerpictureurl set " + " picturea_url = " + "'" + banner1Url + "'" + "," + " pictureb_url = " + "'" + banner2Url + "'" + "," + " picturec_url =" + "'" + banner3Url + "'" + "," + " pictured_url = " + "'" + banner4Url + "'" ;
            SqlCommand sqlcommand = new SqlCommand(str, sqlcon);
            try {
                sqlcommand.ExecuteNonQuery();
                return "ok";
            }
            catch(Exception e){
                return e + "";
            }
        }
    }
}