
namespace Gordias.Library.Headquarters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;

    public class ReflectionBooster
    {
        /// <summary>
        /// シングルトンインスタンス
        /// </summary>
        public static readonly ReflectionBooster Instance = new ReflectionBooster();

        /// <summary>
        /// メソッドリスト
        /// </summary>
        private Dictionary<string, MethodInfo[]> methodInfos = new Dictionary<string, MethodInfo[]>();

        /// <summary>
        /// メソッド
        /// </summary>
        private Dictionary<string, MethodInfo> methodInfo = new Dictionary<string, MethodInfo>();

        /// <summary>
        /// プロパティリスト
        /// </summary>
        private Dictionary<string, PropertyInfo[]> propertyInfos = new Dictionary<string, PropertyInfo[]>();

        /// <summary>
        /// プロパティ
        /// </summary>
        private Dictionary<string, PropertyInfo> propertyInfo = new Dictionary<string, PropertyInfo>();

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        static ReflectionBooster()
        {
        }

        /// <summary>
        /// シングルトン化コード
        /// </summary>
        private ReflectionBooster()
        {
        }

        /// <summary>
        /// メソッド情報リスト取得
        /// </summary>
        /// <param name="type">型</param>
        /// <param name="bindingAttr">属性</param>
        /// <returns>メソッドリスト</returns>
        public MethodInfo[] GetMethods(Type type, BindingFlags bindingAttr = BindingFlags.Public)
        {
            string key = type.FullName + bindingAttr.ToString();

            if (!this.methodInfos.ContainsKey(key))
            {
                var infos= type.GetMethods(bindingAttr);
                this.methodInfos.Add(key, infos);
            }
            return this.methodInfos[key];
        }

        /// <summary>
        /// メソッド情報取得
        /// </summary>
        /// <param name="type">型</param>
        /// <param name="name">メソッド名</param>
        /// <param name="bindingAttr">属性</param>
        /// <returns>メソッド情報</returns>
        public MethodInfo GetMethod(Type type, string name, BindingFlags bindingAttr = BindingFlags.Public)
        {
            string key = type.FullName + bindingAttr.ToString();

            if (!this.methodInfo.ContainsKey(key))
            {
                var info = type.GetMethod(name, bindingAttr);
                this.methodInfo.Add(key, info);
            }
            return this.methodInfo[key];
        }

        /// <summary>
        /// プロパティ情報リスト取得
        /// </summary>
        /// <param name="type">型</param>
        /// <param name="bindingAttr">属性</param>
        /// <returns>プロパティ情報</returns>
        public PropertyInfo[] GetProperties(Type type, BindingFlags bindingAttr)
        {
            string key = type.FullName + bindingAttr.ToString();

            if (!this.propertyInfos.ContainsKey(key))
            {
                var infos = type.GetProperties(bindingAttr);
                this.propertyInfos.Add(key, infos);
            }
            return this.propertyInfos[key];
        }

        /// <summary>
        /// プロパティ情報取得
        /// </summary>
        /// <param name="type">型</param>
        /// <param name="name">プロパティ名</param>
        /// <param name="bindingAttr">属性</param>
        /// <returns>プロパティ情報</returns>
        public PropertyInfo GetProperty(Type type, string name, BindingFlags bindingAttr = BindingFlags.Public)
        {
            string key = type.FullName + bindingAttr.ToString();

            if (!this.propertyInfo.ContainsKey(key))
            {
                //var info = type.GetProperty(name, bindingAttr);
                var info = type.GetProperty(name);
                this.propertyInfo.Add(key, info);
            }
            return this.propertyInfo[key];
        }
    }
}
