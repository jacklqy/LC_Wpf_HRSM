﻿#region Description
/*================================================================================
 *  Copyright (c) ZoomCommerce  All rights reserved.
 * ===============================================================================
 * Solution: ZoomCommerce.BillingSystem.Utility
 * Module:  XmlHelper
 * Descrption:
 * CreateDate: 2013/08/01 11:06:14
 * Author: Eleven
 * Email: Eleven_xuyang@163.com
 * Version:1.0
 * ===============================================================================*/
#endregion
using System;
using System.Linq;
using System.Xml;
using System.Reflection;
using System.Data;
using System.Collections.Generic;

namespace FTree.Framework.Extension
{
    public static class xHelper
    {
        /// <summary>   
        /// 实体转化为XML   
        /// </summary>   
        public static string ParseToXml<T>(this T model, string fatherNodeName)
        {
            var xmldoc = new XmlDocument();
            var modelNode = xmldoc.CreateElement(fatherNodeName);
            xmldoc.AppendChild(modelNode);

            if (model != null)
            {
                foreach (PropertyInfo property in model.GetType().GetProperties())
                {
                    var attribute = xmldoc.CreateElement(property.Name);
                    if (property.GetValue(model, null) != null)
                        attribute.InnerText = property.GetValue(model, null).ToString();
                    //else
                    //    attribute.InnerText = "[Null]";
                    modelNode.AppendChild(attribute);
                }
            }
            return xmldoc.OuterXml;
        }

        /// <summary>   
        /// XML转换为实体,默认 fatherNodeName="body"
        /// </summary> 
        public static T ParseToModel<T>(this string xml, string fatherNodeName = "body") where T : class ,new()
        {
            var model = new T();
            if (string.IsNullOrEmpty(xml))
                return default(T);
            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(xml);

            var attributes = xmldoc.SelectSingleNode(fatherNodeName).ChildNodes;
            foreach (XmlNode node in attributes)
            {
                foreach (var property in model.GetType().GetProperties().Where(property => node.Name == property.Name))
                {
                    if (!string.IsNullOrEmpty(node.InnerText))
                    {
                        property.SetValue(model,
                                          property.PropertyType == typeof(Guid)
                                              ? new Guid(node.InnerText)
                                              : Convert.ChangeType(node.InnerText, property.PropertyType), null);
                    }
                    else
                        property.SetValue(model, null, null);
                }
            }
            return model;
        }

        /// <summary>
        /// XML转实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml"></param>
        /// <param name="headtag"></param>
        /// <returns></returns>
        public static List<T> XmlToObjList<T>(this string xml, string headtag)
            where T : new()
        {

            var list = new List<T>();
            XmlDocument doc = new XmlDocument();
            PropertyInfo[] propinfos = null;
            doc.LoadXml(xml);
            //XmlNodeList nodelist = doc.SelectNodes(headtag);  
            XmlNodeList nodelist = doc.SelectNodes(headtag);
            foreach (XmlNode node in nodelist)
            {
                T entity = new T();
                //初始化propertyinfo  
                if (propinfos == null)
                {
                    Type objtype = entity.GetType();
                    propinfos = objtype.GetProperties();
                }
                //填充entity类的属性  
                foreach (PropertyInfo propinfo in propinfos)
                {
                    //实体类字段首字母变成小写的  
                    string name = propinfo.Name.Substring(0, 1) + propinfo.Name.Substring(1, propinfo.Name.Length - 1);
                    XmlNode cnode = node.SelectSingleNode(name);
                    string v = cnode.InnerText;
                    if (v != null)
                        propinfo.SetValue(entity, Convert.ChangeType(v, propinfo.PropertyType), null);
                }
                list.Add(entity);

            }
            return list;

        }
    }
}
