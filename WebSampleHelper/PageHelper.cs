using System;
using System.Collections.Generic;
using System.Text;
using Discuz.Toolkit;

namespace WebSampleHelper
{
    public class PageHelper
    {
        /// <summary>
        /// 生成主题列表的页面显示样式
        /// </summary>
        /// <param name="forumTopicList"></param>
        /// <returns></returns>
        public static string ShowTopicList(ForumTopic[] forumTopicList)
        {
            string ListStyle = "<p><a href=\"{0}\" target=\"_blank\">{1}</a></p>";
            string Result = "";
            if (forumTopicList != null)
            {
                foreach (ForumTopic forumtopic in forumTopicList)
                {
                    Result += string.Format(ListStyle, forumtopic.Url, forumtopic.Title);
                }
            }
            return Result;
        }

        public static string ShowTopic(TopicGetResponse tgr)
        {
            string topicStyle = "Topictitle:{0}<br/>LastPostTime:{1}<br/>Author:{2}<br/>TypeName:{3}<br/>";
            string postStyle = "User:{0}<br/>DateTime:{1}<br/>Message:{2}<br/>";
            topicStyle = string.Format(topicStyle, tgr.Title, tgr.LastPostTime, tgr.Author, tgr.TypeName);
            string posts = "";
            if (tgr.Posts != null)
            {
                foreach (Post p in tgr.Posts)
                {
                    string post = string.Format(postStyle, p.PosterName, p.PostDateTime, p.Message);
                    if (tgr.Attachments != null)
                    {
                        foreach (AttachmentInfo a in tgr.Attachments)
                        {
                            if (a.Pid == p.Pid)
                                post += "Attachment:" + a.Filename + "<br/>";
                        }
                    }
                    post += "<br/>";
                    posts += post;
                }
            }
            return topicStyle + "<br/>" + posts;
        }

        public static string ShowUserMsgBox(MessagesGetResponse mgr)
        {
            if (mgr == null)
                return "";
            string privatemessageStyle = "Subject:{0}<br/>PostDateTime:{1}<br/>From:{2}<br/>Message:{3}<br/>------" +
                "------------------------------------------------------------<br/>";
            string result = "";
            if (mgr.count > 0)
            {
                result += string.Format("Count:{0}<br/>", mgr.count);
                foreach (PrivateMessage pm in mgr.PM)
                {
                    result += string.Format(privatemessageStyle, pm.Subject, pm.PostDateTime, pm.FromUser, pm.Message);
                }
            }
            else
                result = "the messagebox for this user is empty!";
            return result;
        }
    }
}
