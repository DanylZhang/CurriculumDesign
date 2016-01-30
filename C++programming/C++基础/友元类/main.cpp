#include <iostream>
using namespace std;

class TV{
public:
	friend class Tele;//只要放置在类定义内部就行
	TV() :on_off(off), mode(tv), channel(1), volume(20){}
private:
	enum{ off, on };
	enum{ tv, av };
	enum{ mincl = 1, maxcl = 60 };
	enum{ minve, maxve = 100 };
	bool on_off;
	int mode;
	int channel;
	int volume;
};

class Tele{
public:
	void OnOff(TV &t){ t.on_off = ((t.on_off == t.off) ? t.on : t.off); }
	void setMode(TV &t){ t.mode = ((t.mode == t.tv) ? t.av : t.tv); }
	bool VolumeDown(TV &t);
	bool VolumeUp(TV &t);
	bool ChannelDown(TV &t);
	bool ChannelUp(TV &t);
	void show(TV const &t)const;
};
bool Tele::VolumeDown(TV &t)
{
	if (t.volume > t.minve)
	{
		t.volume--;
		return true;
	}
	else
		return false;
}
bool Tele::VolumeUp(TV &t)
{
	if (t.volume<t.maxve)
	{
		t.volume++;
		return true;
	}
	else
		return false;
}bool Tele::ChannelDown(TV &t)
{
	if (t.channel > t.mincl)
	{
		t.channel--;
		return true;
	}
	else
		return false;
}
bool Tele::ChannelUp(TV &t)
{
	if (t.channel < t.maxcl)
	{
		t.channel++;
		return true;
	}
	else
		return false;
}
void Tele::show(TV const &t)const
{
	if (t.on_off == t.on)
	{
		cout << "电视机已打开" << endl;
		cout << "音量大小为：" << t.volume << endl;
		cout << "信号模式：" << ((t.mode == t.tv) ? "TV模式" : "AV模式") << endl;
		cout << "当前电视机的频道：" << t.channel << endl;
	}
	else
		cout << "电视机未打开" << endl;
}

int main()
{
	TV tv;
	Tele tele;
	tele.show(tv);
	tele.OnOff(tv);
	tele.show(tv);
	cout << "调大声音" << endl;
	tele.VolumeUp(tv);
	tele.show(tv);
	cout << "转换模式" << endl;
	tele.setMode(tv);
	tele.show(tv);
	return 0;
}