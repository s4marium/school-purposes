using System;

namespace UserNamespace
{
	// Base class as described in the UML
	public abstract class User
	{
		// - user_id: string (private)
		private string user_id;

		// # user_password: string (protected)
		protected string user_password;

		// + User(string id, string pass)
		protected User(string id, string pass)
		{
			user_id = id;
			user_password = pass;
		}

		// + verifyLogin(string id, string pass): bool
		// Uses Equals() to compare strings as required
		public bool verifyLogin(string id, string pass)
		{
			return (user_id != null && user_id.Equals(id)) &&
				   (user_password != null && user_password.Equals(pass));
		}

		// + updatePassword(string newPassword): void (abstract in UML)
		public abstract void updatePassword(string ne
		Password);
	}

	// Derived class Administrator
	public class Administrator : User
	{
		// - admin_name: string (private)
		private string admin_name;

		// + Administrator(string name, string id, string pass)
		public Administrator(string name, string id, string pass) : base(id, pass)
		{
			admin_name = name;
		}

		// + updatePassword(string newPassword): void (override)
		public override void updatePassword(string newPassword)
		{
			// Because user_password is protected, we can assign it here
			user_password = newPassword;
		}

		// + updateAdminName(string name): void
		public void updateAdminName(string name)
		{
			admin_name = name;
		}
	}
}
