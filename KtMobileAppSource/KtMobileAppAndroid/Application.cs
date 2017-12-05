using System;
using System.IO;
using SQLite;
using Android.App;
using KtMobileAppPortableLibrary;

namespace KtMobileAppAndroid
{
	[Application]
	public class KtMobileApp : Application {
		public static KtMobileApp Current { get; private set; }

		public TodoItemManager TodoManager { get; set; }
		SQLiteConnection conn;

		public KtMobileApp(IntPtr handle, global::Android.Runtime.JniHandleOwnership transfer)
			: base(handle, transfer) {
			Current = this;
		}

		public override void OnCreate()
		{
			base.OnCreate();

			var sqliteFilename = "TodoItemDB.db3";
			string libraryPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			var path = Path.Combine(libraryPath, sqliteFilename);
			conn = new SQLiteConnection(path);

			TodoManager = new TodoItemManager(conn);
		}
	}
}

