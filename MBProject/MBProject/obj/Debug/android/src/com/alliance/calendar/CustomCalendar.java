package com.alliance.calendar;


public class CustomCalendar
	extends android.widget.LinearLayout
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("com.alliance.calendar.CustomCalendar, com.alliance.calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4c141ae9ea39bdad", CustomCalendar.class, __md_methods);
	}


	public CustomCalendar (android.content.Context p0) throws java.lang.Throwable
	{
		super (p0);
		if (getClass () == CustomCalendar.class)
			mono.android.TypeManager.Activate ("com.alliance.calendar.CustomCalendar, com.alliance.calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4c141ae9ea39bdad", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0 });
	}


	public CustomCalendar (android.content.Context p0, android.util.AttributeSet p1) throws java.lang.Throwable
	{
		super (p0, p1);
		if (getClass () == CustomCalendar.class)
			mono.android.TypeManager.Activate ("com.alliance.calendar.CustomCalendar, com.alliance.calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4c141ae9ea39bdad", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065", this, new java.lang.Object[] { p0, p1 });
	}


	public CustomCalendar (android.content.Context p0, android.util.AttributeSet p1, int p2) throws java.lang.Throwable
	{
		super (p0, p1, p2);
		if (getClass () == CustomCalendar.class)
			mono.android.TypeManager.Activate ("com.alliance.calendar.CustomCalendar, com.alliance.calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4c141ae9ea39bdad", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public CustomCalendar (android.content.Context p0, android.util.AttributeSet p1, int p2, int p3) throws java.lang.Throwable
	{
		super (p0, p1, p2, p3);
		if (getClass () == CustomCalendar.class)
			mono.android.TypeManager.Activate ("com.alliance.calendar.CustomCalendar, com.alliance.calendar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=4c141ae9ea39bdad", "Android.Content.Context, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:Android.Util.IAttributeSet, Mono.Android, Version=0.0.0.0, Culture=neutral, PublicKeyToken=84e04ff9cfb79065:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.Int32, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1, p2, p3 });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
