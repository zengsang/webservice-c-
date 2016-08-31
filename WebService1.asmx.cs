using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace sign_Online
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        Dboperation db = new Dboperation();
     

         [WebMethod]
         /* 查询用户信息
         * Sselect
         * @param username
         */
        public List<String> Sselect(String useremail) {
           return db.Sselect(useremail);
        }


         [WebMethod]

         /* 插入用户的简单信息
          * Sinsert
          * @param useremail
          * @param userpassword
          */
         public String Sinsertimportusermsg(String useremail, String userpassword)
         {
             return db.Sinsertimportusermsg(useremail, userpassword);
         }

         [WebMethod]
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
         public String Supdate(String useremail, String newusername, String newuserreallyname, String newphonenumber, String newusersex, String newuseryearold)
         {
            return db.Supdate(useremail,newusername,newuserreallyname,newphonenumber,newusersex,newuseryearold);
        }



         [WebMethod]
         /* 更新插入用户详细信息用户信息
      * Supdate
       * @param useremail
       * @param username
       * @param userreallyname
       * @param userphonenumber
       * @param usersex
      */
         public String Sunimportantupdate(String useremail, String username, String userreallyname, String userphonenumber, String usersex, String useryearold)
         {
             return db.Sunimportantupdate(useremail, username, userreallyname, userphonenumber, usersex, useryearold);
         }

         [WebMethod]

         /* 更新某一项用户基本信息用户信息
        * Supdate
         * @param useremail（用户邮箱）
         * @param property（等待更新的属性名）
         * @param newvalue（新的值）
          */
         public String Soneupdate(String useremail, String property, String newvalue)
         {
            return db.Soneupdate(useremail,property,newvalue);
         }

        [WebMethod]
       /*注销用户
        * Sdelete
        * @param username
        */
         public bool Sdelete(String username) {
            return db.Sdelete(username);
         }

        [WebMethod]
          /*对广告轮转图表查询操作，用户客户端获取广告url
         * Sselectpictureurl
         */
        public List<String> Sselectpictureurl() {
            return db.Sselectpictureurl();
        }

        [WebMethod]
        /*在服务器端创建相应的用户文件夹，远程提供用户信息
         * Inituserfile
         * @param useremail
         *@return bool
         */
        public bool Inituserfile(String useremail)
        {
           return db.Inituserfile(useremail);
        }

        [WebMethod]
        /*将用户的头像存在服务器相应目录
         * Saveusericon
         * @param String useremail 用户邮箱
         * @param byte usericonbyte 用户头像字节流
         */
        public bool Saveusericon(String useremail, byte[] usericonbyte) {
            return db.Saveusericon(useremail,usericonbyte);
        }

        [WebMethod]
            /*将用户的协议模板进行保存 保存成txt 其中txt名为模板名 txt内容为模板
         * Saveprotocelmould
         * @param String useremail 用户邮箱
         * @param String protocelmouldname 协议模板名
         * @param String protocelmouldcontent 协议模板体
         */
        public String Saveprotocelmould(String useremail, String protocelmouldname, String protocelmouldcontent)
        { 
            return db.Saveprotocelmould(useremail,protocelmouldname,protocelmouldcontent);
        }


        [WebMethod]
        /*将用户的协议（图片）存在服务器相应目录
       * Saveuserprotocel
       * @param String useremail 用户邮箱
       * @param byte[] usericonbyte 用户协议图片字节流
       * @param String protocelmouldname 协议所属的模板名
        * @param String date 协议书写的日期
       */
        public String Saveuserprotocel(String useremail, String protocelmouldname, String date, String protocelstring)
        {
            return db.Saveuserprotocel(useremail, protocelmouldname, date, protocelstring);
        }

        [WebMethod]
        /*从服务器文件中读取用户的头像
      * Getusericon
      * @param useremail
      */
        public List<String> Getusericon(String useremail)
        {
            return db.Getusericon(useremail);
        }


        [WebMethod]
        /*从服务器文件中读取用户的协议模板
         * Getprotocelmould
         * @param useremail
         * return List<String>
         */
        public List<String> Getprotocelmould(String useremail)
        {
            return db.Getprotocelmould(useremail);
        }

        [WebMethod]
         /*从服务器文件中读取用户的协议以及对应的协议模板名
         * Getprotocelmould
         * @param useremail
         * return List<String>
         */
        public List<String> Getprotocel(String useremail)
        {
            return db.Getprotocel(useremail);
        }

        [WebMethod]
        /*将用户的反馈储存到本地用户文件夹
        *Saveusersuggestion
        *@String useremail  用户邮箱
        *@String usersuggestion 用户反馈
        */
        public String Saveusersuggestion(String useremail, String usersuggestion)
        {
           return db.Saveusersuggestion(useremail,usersuggestion);
        }


          [WebMethod]
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
          return  db.Savetranslatefiletoserver(sendport,receiveport,filename,filecontent,filecontent);
        }


          [WebMethod]
         /*查询特定接收者并且没有被接收的接受信息
         * Gettranslatemsgbyrecevier
         * @param recevieport  接收方
         * @return List<String>
         */
        public List<String> Gettranslatemsgbyreceiver(String recevieport) {
            return db.Gettranslatemsgbyreceiver(recevieport);
            }


          [WebMethod]
           /*用户用户在客户端接收好友发来的文件
         * Gettranslatefilebyrecevier
         * @param receiveport 接收方名
         * @param filename 需要接收的文件名
         * @return String
         */
        public List<String> Gettranslatefilebyreceiver(String filename, String receiveport)
        {
            return db.Gettranslatefilebyreceiver(filename,receiveport);
        }

        [WebMethod]
          /*用户用户在客户端接收好友发来的文件后，删除该文件
         * Gettranslatefilebyrecevier
         * @param receiveport 接收方名
         * @param filename 需要接收的文件名
         * @return String
         */
          public String Deletetranslatefile(String filename, String receiveport)
          {
             return db.Deletetranslatefile(filename,receiveport);
          }

        [WebMethod]
        /*删除某个协议
     * DeleteMyProtocel
     * @param userEmail  用户邮箱
     * @param protocelMoudelName  模板名称
     * @param protocelName 用户协议名
     */
        public String DeleteMyProtocel(String userEmail, String protocelMoudelName, String protocelName)
        {
            return db.DeleteMyProtocel(userEmail, protocelMoudelName, protocelName);
        }

        [WebMethod]
        /*更新客户端banner图片的地址
    * UpdateBannerPictureUrl
    * @param banner1Url
    * @param banner2Url
    * @param banner3Url
    * @param banner4Url
    */
        public String UpdateBannerPictureUrl(String banner1Url, String banner2Url, String banner3Url, String banner4Url)
        {
            return db.UpdateBannerPictureUrl(banner1Url,banner2Url,banner3Url,banner4Url);

        }

    }


 

 

   
}
