// See https://aka.ms/new-console-template for more information

//this is just a quick demo of the 14 types of data shown in this chapter


//char and string types
//two types
char ch = 'a';
string str = "letters";

//bool type
//one type
bool b = true;

//int types
//eight types
byte bInt = 1;      //unsigned, 0 to 255
short sInt = 2;     //signed -32768 to 32767
int nInt = 3;       //signed -2147483648 to 2147483647
long lInt = 4;      //signed tiny to huge
sbyte sbInt = 5;    //signed -128 to 127
ushort usInt = 6;   //unsigned 0 to 65535
uint uInt = 7;      //unisgned 0 to 4294967295
ulong ulInt = 8;    //unsigned 0 to huge-er

//float types
//three types
float fl = 1.278f;     //signed 7 digit precision
double db = 1.43;      //signed 15-16 digit precision
decimal dc = 1.765m;   //signed 28-29 digit precision

Console.WriteLine(ch);
Console.WriteLine(str);
Console.WriteLine(b);
Console.WriteLine(bInt);
Console.WriteLine(sInt);
Console.WriteLine(nInt);
Console.WriteLine(lInt);
Console.WriteLine(sbInt);
Console.WriteLine(usInt);
Console.WriteLine(uInt);
Console.WriteLine(ulInt);
Console.WriteLine(fl);
Console.WriteLine(db);
Console.WriteLine(dc);



//this is part two of the challenge
ch = 'b';
str = "more letters";
b = false;
bInt = 2;
sInt = 4;
nInt = 10;
lInt = 22;
sbInt = 11;
usInt = 12;
uInt = 26;
ulInt = 27;
fl = 42.12f;
db = 44.44;
dc = 44.4444m;

Console.WriteLine(ch);
Console.WriteLine(str);
Console.WriteLine(b);
Console.WriteLine(bInt);
Console.WriteLine(sInt);
Console.WriteLine(nInt);
Console.WriteLine(lInt);
Console.WriteLine(sbInt);
Console.WriteLine(usInt);
Console.WriteLine(uInt);
Console.WriteLine(ulInt);
Console.WriteLine(fl);
Console.WriteLine(db);
Console.WriteLine(dc);