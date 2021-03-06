#include <stdio.h>
#include<stdlib.h>
#include <string.h>
#include<conio.h>
#define ACC -2
/********************************/
#define sy_if     0
#define sy_then   1
#define sy_else   2
#define sy_while  3
#define sy_begin  4
#define sy_do     5
#define sy_end    6
#define a         7
#define semicolon 8
#define e         9
#define jinghao   10
#define S         11
#define L         12
#define tempsy    15
#define EA        18
#define E0        19
#define plus      34
#define times     36
#define becomes   38
#define op_and    39
#define op_or     40
#define op_not    41
#define rop       42
#define lparent   48
#define rparent   49
#define ident     56
#define intconst  57
#define div       58
#define varconst  59
/***********************************/
char ch='\0';          //从字符缓冲区中读取当前字符 
int count=0;		//词法分析结果缓冲区计数器 

static char spelling[10]={""}; //存放识别的字 
static char line[81]={""};		//一行字符缓冲区（最多80个字符） 

char *pline;		//字符缓冲区指针 

static char ntab1[100][10];  //变量名表：共100项，每项长度为10 
static char ntab3[100][10];
int tt1=0;//变量名表指针 
int tt3=0;
int nlength=0;//词法分析中记录单词的长度 
int length3=0;

struct ntab
{
    int tc;//真值 
    int fc;//假值 
}ntab2[200];//在布尔表达式e中保存有关布尔变量的真、假值 
int label=0;//指向ntab2的指针 

struct rwords 
{
    char sp[10];
    int sy;
};//匹配表的结构，用来与输入缓冲区中的单词进行匹配 

struct rwords reswords[10]=
{
    {"if",sy_if},
    {"do",sy_do},
    {"else",sy_else},
    {"while",sy_while},
    {"then",sy_then},
    {"begin",sy_begin},
    {"end",sy_end},
    {"and",op_and},
    {"or",op_or},
    {"not",op_not}
};	//匹配表初始化，大小为10 

struct aa
{
    int syl;//存放名字 
    int pos;//存放名字所对应的地址 
}buf[1000], //词法分析结果缓冲区 
n, //读取二元式的当前字符 
n1,//当前表达式中的字符 
E,//非终结符 
sstack[100],//算术或布尔表达式加工处理使用的符号栈 
ibuf[100],//算术或布尔表达式使用的缓冲区 
stack[1000];//语法分析加工处理使用的符号栈 

struct aa oth;//四元式中空白位置 
struct fourexp
{
    char op[10];
    struct aa arg1;
    struct aa arg2;
    int result;
}fexp[200];//四元式的结构定义 

int ssp=0;//指向sstack栈指针 
struct aa *pbuf=buf;//指向词法分析缓冲区的指针 

int lnum=0;//源程序行数记录 

FILE   *cfile;//源程序文件，~为结束符 
/***************************************************/
int newt=0,//临时变量计数器 
nxq=100,//nxq总是指向下一个将要形成的四元式地址，每次执行gen（）时，地址自动增1 
lr,//扫描LR分析表1过程中保存的当前状态值 
lr1,//扫描LR分析表2或表3所保存的当前状态值 
sp=0,//查找LR分析表时状态栈的栈顶指针 
stack1[100],//状态栈1定义 
sp1=0,//状态栈1的栈顶指针 
num=0;//算术或布尔表达式缓冲区指针 

struct ll
{
    int nxq1;//记录下一条四元式的地址 
    int tc1;//真值链 
    int fc1;//假值链 
}labelmark[10];//记录语句嵌套层次的数组，即记录嵌套中每层的布尔表达式e的首地址 

int labeltemp[10],//记录语句嵌套层次的数组，即记录每一层else之前的四元式地址 
pointmark=-1,//labelmark数组指针 
pointtemp=-1,//labeltemp数组指针 
sign=0;//sign=1为赋值语句；sign=2为while语句；sign=3为if语句 
/*****************程序语句的LR分析表************************/
static int action[19][13]=
{
/*0*/    { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, 10, 1,-1},
/*1*/    {-1,-1, -1,-1,-1,-1, -1,-1, -1,-1,ACC,-1,-1},
/*2*/    {-1,-1, -1,-1,-1,-1, -1,-1, -1, 6, -1,-1,-1},
/*3*/    {-1,-1, -1,-1,-1,-1, -1,-1, -1, 7, -1,-1,-1},
/*4*/    { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, -1, 9, 8},
/*5*/    {-1,-1,104,-1,-1,-1,104,-1,104,-1,104,-1,-1},
/*6*/    {-1,10, -1,-1,-1,-1, -1,-1, -1,-1, -1,-1,-1},
/*7*/    {-1,-1, -1,-1,-1,11, -1,-1, -1,-1, -1,-1,-1},
/*8*/    {-1,-1, -1,-1,-1,-1, 12,-1, -1,-1, -1,-1,-1},
/*9*/    {-1,-1, -1,-1,-1,-1,105,-1, 13,-1, -1,-1,-1},
/*10*/   { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, -1,14,-1},
/*11*/   { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, -1,15,-1},
/*12*/   {-1,-1,103,-1,-1,-1,103,-1,103,-1,103,-1,-1},
/*13*/   { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, -1, 9,16},
/*14*/   {-1,-1, 17,-1,-1,-1,107,-1,107,-1,107,-1,-1},
/*15*/   {-1,-1,102,-1,-1,-1,102,-1,102,-1,102,-1,-1},
/*16*/   {-1,-1, -1,-1,-1,-1,106,-1, -1,-1, -1,-1,-1},
/*17*/   { 2,-1, -1, 3, 4,-1, -1, 5, -1,-1, -1,18,-1},
/*18*/   {-1,-1,101,-1,-1,-1,101,-1,101,-1,101,-1,-1}
};

/*****************算术表达式的LR分析表***********************/
static int action1[12][8]=
{
/*0*/   { 3, -1, -1,  2, -1, -1, 1, -1},
/*1*/   {-1,  4,  5, -1, -1,ACC,-1, 10},
/*2*/   { 3, -1, -1,  2, -1, -1, 6, -1},
/*3*/   {-1,104,104, -1,104,104,-1,104},
/*4*/   { 3, -1, -1,  2, -1, -1, 7, -1},
/*5*/   { 3, -1, -1,  2, -1, -1, 8, -1},
/*6*/   {-1,  4,  5, -1,  9, -1,-1, 10},
/*7*/   {-1,101,  5, -1,101,101,-1, 10},
/*8*/   {-1,102,102, -1,102,102,-1,102},
/*9*/   {-1,103,103, -1,103,103,-1,103},
/*10*/  { 3, -1, -1,  2, -1, -1,11, -1},
/*11*/  {-1,105,105, -1,105,105,-1,105}
};

/****************布尔表达式的LR分析表************************/
static int action2[16][11]=
{
/*0*/    {  1,-1,  4, -1,  5, -1, -1, -1,13, 7, 8},
/*1*/    { -1, 2, -1,101, -1,101,101,101,-1,-1,-1},
/*2*/    {  3,-1, -1, -1, -1, -1, -1, -1,-1,-1,-1},
/*3*/    { -1,-1, -1,102, -1,102,102,102,-1,-1,-1},
/*4*/    {  1,-1,  4, -1,  5, -1, -1, -1,11, 7, 8},
/*5*/    {  1,-1,  4, -1,  5, -1, -1, -1, 6, 7, 8},
/*6*/    { -1,-1, -1,104, -1,  9, 10,104,-1,-1,-1},
/*7*/    {  1,-1,  4, -1,  5, -1, -1, -1,14, 7, 8},
/*8*/    {  1,-1,  4, -1,  5, -1, -1, -1,15, 7, 8},
/*9*/    {105,-1,105, -1,105, -1, -1, -1,-1,-1,-1},
/*10*/   {107,-1,107, -1,107, -1, -1, -1,-1,-1,-1},
/*11*/   { -1,-1, -1, 12, -1,  9, 10, -1,-1,-1,-1},
/*12*/   { -1,-1, -1,103, -1,103,103,103,-1,-1,-1},
/*13*/   { -1,-1, -1, -1, -1,  9, 10,ACC,-1,-1,-1},
/*14*/   { -1,-1, -1,106, -1,  9, 10,106,-1,-1,-1},
/*15*/   { -1,-1, -1,108, -1,  9, 10,108,-1,-1,-1},
};

/****************从文件读一行到缓冲区**********************/
void readline()
{
    char ch1;
    pline=line;
    ch1=getc(cfile);
    while(ch1!='\n')
    {
        *pline=ch1;
        pline++;
        ch1=getc(cfile);
    }
    *pline='\0';
    pline=line;
}

/***************从缓冲区读取一个字符************************/
void readch()
{
    if(ch=='\0')
    {
        readline();
        lnum++;
    }
    ch=*pline;
    pline++;
}

/****************标识符和关键字的识别*************************/
int find(char spel[],char tab[100][10],int length)
{
    int ss1=0,ii=0;
    while((ss1==0)&&(ii<length))
    {
        if(!strcmp(spel,tab[ii])) ss1=1;
        ii++;
    }
    if(ss1==1) return ii-1;
    else return -1;
}

void identifier()
{
    int iii=0,j,k=0,ss=0;
    do
    {
        spelling[k]=ch;
        k++;
        readch();
    }while(((ch>='a')&&(ch<='z'))||((ch>='0')&&(ch<='9')));
    pline--;
    spelling[k]='\0';
    while((ss==0)&&(iii<10))
    {
        if(!strcmp(spelling,reswords[iii].sp)) ss=1;
        iii++;
    }
    /*关键字匹配*/
    if(ss==1)   buf[count].syl=reswords[iii-1].sy;
    else
    {
        buf[count].syl=ident;
         j=find(spelling,ntab1,nlength);
        if(j==-1)
        {
            buf[count].pos=tt1;
            strcpy(ntab1[tt1],spelling);
            tt1++;
            nlength++;
        }
        else buf[count].pos=j;
    }
    count++;
    for(k=0;k<10;k++) spelling[k]=' ';
}

/*******************数字识别******************************/
void number()
{
    int ivalue=0,digit,k=0,j;
    do
    {
    	digit=ch-'0';
    	ivalue=ivalue*10+digit;
	spelling[k]=ch;
	k++; 
    	readch();
     }while((ch>='0')&&(ch<='9'));
	if(ch=='.')
	{
		spelling[k]=ch;
		k++;
		readch();
		while((ch>='0')&&(ch<='9'))
		{
			spelling[k]=ch;
			k++;
			readch();	
		}
		spelling[k]='\0';
		buf[count].syl=varconst;
		j=find(spelling,ntab3,length3);
		if(j==-1)
		{
			buf[count].pos=tt3;
			strcpy(ntab3[tt3],spelling);
			tt3++;
			length3++;		
		}
		else
		{
			buf[count].pos=j;
		}
	}
	else{
    	buf[count].syl=intconst;
    	buf[count].pos=ivalue;		
	} 
    count++;
    pline--;
    for(k=0;k<10;k++) spelling[k]=' ';
}

/*****************扫描主函数***************************/
void scan()
{
    int i;
    while(ch!='~')
    {
        switch(ch)
        {
            case ' ': break;
            case 'a':
            case 'b':
            case 'c':
            case 'd':
            case 'e':
            case 'f':
            case 'g':
            case 'h':
            case 'i':
            case 'j':
            case 'k':
            case 'l':
            case 'm':
            case 'n':
            case 'o':
            case 'p':
            case 'q':
            case 'r':
            case 's':
            case 't':
            case 'u':
            case 'v':
            case 'w':
            case 'x':
            case 'y':
            case 'z':
                identifier();break;
            case '0':
            case '1':
            case '2':
            case '3':
            case '4':
            case '5':
            case '6':
            case '7':
            case '8':
            case '9':
                number();break;
            case '<':
                readch();
                if(ch=='=') buf[count].pos=0;
                else
                {
                    if(ch=='>') buf[count].pos=4;
                    else
                    {
                        buf[count].pos=1;   /*  '<'标志   */
                        pline--;
                    }
                }
                buf[count].syl=rop;
                count++;
                break;
            case '>':
                readch();
                if(ch=='=') buf[count].pos=2;   /*  '>='标志  */
                else
                {
                    buf[count].pos=3;
                    pline--;
                }
                buf[count].syl=rop;
                count++;
                break;
            case '(':
                buf[count].syl=lparent;
                count++;
                break;
            case ')':
                buf[count].syl=rparent;
                count++;
                break;
            case '#':
                buf[count].syl=jinghao;
                count++;
                break;
            case '+':
                buf[count].syl=plus;
                count++;
                break;
            case '*':
                buf[count].syl=times;
                count++;
                break;
            case '/':
            	buf[count].syl=div;
            	count++;
            	break;
            case ':':
                readch();
                if(ch=='=') buf[count].syl=becomes; /*  ':='标志  */
                count++;
                break;
            case '=':
                buf[count].syl=rop; /*  关系运算标志  */
                buf[count].pos=5;   /*  '=' 标志  */
                count++;
                break;
            case ';':
                buf[count].syl=semicolon;
                count++;
                break;
        }
        readch();
    }
    buf[count].syl=-1;
}

/**************************************************************/
void readnu()
{
    if(pbuf->syl>=0)
    {
        n.syl=pbuf->syl;
        n.pos=pbuf->pos;
        pbuf++;
    }
}

/***********************中间变量的生成****************************/
int newtemp()
{
    newt++;
    return newt;
}

/**********************生成四元式***********************************/
int gen(char op1[],struct aa arg11,struct aa arg22,int result1)
{
    strcpy(fexp[nxq].op,op1);
    fexp[nxq].arg1.syl=arg11.syl;
    fexp[nxq].arg1.pos=arg11.pos;
    fexp[nxq].arg2.syl=arg22.syl;
fexp[nxq].arg2.pos=arg22.pos;
fexp[nxq].result=result1;
    nxq++;
    return nxq-1;
}

/**********************布尔表达式的匹配*********************/
int merg(int p1,int p2)
{
    int p;
    if(p2==0) return p1;
    else
    {
        p=p2;
        while(fexp[p].result!=0) p=fexp[p].result;
        fexp[p].result=p1;
        return p2;
    }
}

void backpatch(int p,int t)
{
    int tempq,q;
    q=p;
    while(q!=0)
    {
        tempq=fexp[q].result;
        fexp[q].result=t;
        q=tempq;
    }
}

/***************************************************************************/
int change1(int chan)
{
    switch(chan)
    {
        case ident:
        case intconst:
        case varconst:  return 0;
        case plus:      return 1;
        case times:     return 2;
        case lparent:   return 3;
        case rparent:   return 4;
        case jinghao:   return 5;
        case tempsy:    return 6;
        case div:		return 7;
    }
}

int change2(int chan)
{
    switch(chan)
    {
        case ident:
        case intconst: 
		case varconst: return 0;
        case rop:      return 1;
        case lparent:   return 2;
        case rparent:   return 3;
        case op_not:   return 4;
        case op_and:   return 5;
        case op_or:    return 6;
        case jinghao:   return 7;
        case tempsy:   return 8;
        case EA:    return 9;
        case E0:    return 10;
    }
}

/************************赋值语句的分析***************************/
int lrparse1(int num)
{
    lr1=action1[stack1[sp1]][change1(n1.syl)];
    if(lr1==-1)
    {
        printf("\n算术表达式或赋值语句出错!\n");
        getch();
        exit(0);
    }
    if((lr1<12)&&(lr1>=0))  /*移进*/
    {
        sp1++;
        stack1[sp1]=lr1;
        if(n1.syl!=tempsy)
        {
            ssp++;
            num++;
            sstack[ssp].syl=n1.syl;
            sstack[ssp].pos=n1.pos;
        }
        n1.syl=ibuf[num].syl;
        n1.pos=ibuf[num].pos;
        lrparse1(num);
    }
    if((lr1>=100)&&(lr1<106))   /*归约*/
    {
        switch(lr1)
        {
            case 100:   /*S'->E*/
                break;
            case 101:   /*E->E+E*/
                E.pos=newtemp();
                gen("+",sstack[ssp-2],sstack[ssp],E.pos+100);
                ssp=ssp-2;
                sstack[ssp].syl=tempsy;
                sstack[ssp].pos=E.pos;
                sp1=sp1-3;
                break;
            case 102:   /*E->E*E*/
                E.pos=newtemp();
                gen("*",sstack[ssp-2],sstack[ssp],E.pos+100);
                ssp=ssp-2;
                sstack[ssp].syl=tempsy;
                sstack[ssp].pos=E.pos;
                sp1=sp1-3;
                break;
            case 103:   /*E->(E)*/
                E.pos=sstack[ssp-1].pos;
                ssp=ssp-2;
                sstack[ssp].syl=tempsy;
                sstack[ssp].pos=E.pos;
                sp1=sp1-3;
                break;
            case 104:   /*E->i*/
                E.pos=sstack[ssp].pos;
                sp1--;
                break;
            case 105:
            	E.pos=newtemp();
            	gen("/",sstack[ssp-2],sstack[ssp],E.pos+100);
            	ssp=ssp-2;
                sstack[ssp].syl=tempsy;
                sstack[ssp].pos=E.pos;
                sp1=sp1-3;
                break;
        }
        n1.syl=tempsy;
        n1.pos=E.pos;
        lrparse1(num);
    }
    if((lr1==ACC)&&(stack1[sp1]==1))    /*归约A->i:E*/
    {
        gen(":=",sstack[ssp],oth,ibuf[0].pos);
        ssp=ssp-3;
        sp1=sp1-3;
    }
    return 0;
}

/****************************布尔表达式的分析******************************/
int lrparse2(int num)
{
    int templabel;
    lr1=action2[stack1[sp1]][change2(n1.syl)];
    if(lr1==-1)
    {
        if(sign==2) printf("\nwhile语句出错!\n");
        if(sign==3) printf("\nif语句出错!\n");
        getch();
        exit(0);
    }
    if((lr1<16)&&(lr1>=0))  /*移进*/
    {
        sp1++;
        stack1[sp1]=lr1;
        ssp++;
        sstack[ssp].syl=n1.syl;
        sstack[ssp].pos=n1.pos;
        if((n1.syl!=tempsy)&&(n1.syl!=EA)&&(n1.syl!=E0))    num++;
        n1.syl=ibuf[num].syl;
        n1.pos=ibuf[num].pos;
        lrparse2(num);
    }
    if((lr1>=100)&&(lr1<109))   /*归约*/
    {
        switch(lr1)
        {
            case 100:   /*S'->B*/
                break;
            case 101:   /*B->i*/
                ntab2[label].tc=nxq;
                ntab2[label].fc=nxq+1;
                gen("jnz",sstack[ssp],oth,0);
                gen("j",oth,oth,0);
                sp1--;
                ssp--;
                label++;
                n1.syl=tempsy;
                break;
            case 102:   /*B->i rop i*/
                ntab2[label].tc=nxq;
                ntab2[label].fc=nxq+1;
                switch(sstack[ssp-1].pos)
                {
                    case 0:
                        gen("j<=",sstack[ssp-2],sstack[ssp],0);
                        break;
                    case 1:
                        gen("j<",sstack[ssp-2],sstack[ssp],0);
                        break;
                    case 2:
                        gen("j>=",sstack[ssp-2],sstack[ssp],0);
                        break;
                    case 3:
                        gen("j>",sstack[ssp-2],sstack[ssp],0);
                        break;
                    case 4:
                        gen("j<>",sstack[ssp-2],sstack[ssp],0);
                        break;
                    case 5:
                        gen("j=",sstack[ssp-2],sstack[ssp],0);
                        break;
                }
                gen("j",oth,oth,0);
                ssp=ssp-3;
                sp1=sp1-3;
                label++;
                n1.syl=tempsy;
                break;
            case 103:   /*B->(B)*/
                label=label-1;
                ssp=ssp-3;
                sp1=sp1-3;
                label++;
                n1.syl=tempsy;
                break;
            case 104:   /*B->not B*/
                label=label-1;
                templabel=ntab2[label].tc;
                ntab2[label].tc=ntab2[label].fc;
                ntab2[label].fc=templabel;
                ssp=ssp-2;
                sp1=sp1-2;
                label++;
                n1.syl=tempsy;
                break;
            case 105:   /*A->Band*/
                backpatch(ntab2[label-1].tc,nxq);
                label=label-1;
                ssp=ssp-2;
                sp1=sp1-2;
                label++;
                n1.syl=EA;
                break;
            case 106:   /*B->AB*/
                label=label-2;
                ntab2[label].tc=ntab2[label+1].tc;
                ntab2[label].fc=merg(ntab2[label].fc,ntab2[label+1].fc);
                ssp=ssp-2;
                sp1=sp1-2;
                label++;
                n1.syl=tempsy;
                break;
            case 107:   /*0->B or*/
                backpatch(ntab2[label-1].fc,nxq);
                label=label-1;
                ssp=ssp-2;
                sp1=sp1-2;
                label++;
                n1.syl=E0;
                break;
            case 108:   /*B->0B*/
                label=label-2;
                ntab2[label].fc=ntab2[label+1].fc;
                ntab2[label].tc=merg(ntab2[label].tc,ntab2[label+1].tc);
                ssp=ssp-2;
                sp1=sp1-2;
                label++;
                n1.syl=tempsy;
                break;
        }
        lrparse2(num);
    }
    if(lr1==ACC) return 1;
}

/*************************测试字符是否为表达式中的值（不包括"；"）*****************/
int test(int value)
{
    switch(value)
    {
        case ident:
        case intconst:
        case varconst:
        case plus:
        case times:
        case div:
        case becomes:
        case lparent:
        case rparent:
        case rop:
        case op_not:
        case op_and:
        case op_or:
            return 1;
        default : return 0;
    }
}

/**************************************************************/
int lrparse()   /*程序语句处理*/
{
    int i1=0,num=0;
    /*指向表达式缓冲区*/
    if(test(n.syl))
    {
        if(stack[sp].syl==sy_while) sign=2;
        else
        {
            if(stack[sp].syl==sy_if)    sign=3;
            else sign=1;
        }
        do
        {
            ibuf[i1].syl=n.syl;
            ibuf[i1].pos=n.pos;
            readnu();
            i1++;
        }while(test(n.syl));
        ibuf[i1].syl=jinghao;
        pbuf--;
        sstack[0].syl=jinghao;
        ssp=0;
        if(sign==1) /*赋值语句处理*/
        {
            sp1=0;
            stack1[sp1]=0;
            num=2;
            n1.syl=ibuf[num].syl;
            n1.pos=ibuf[num].pos;
            lrparse1(num);
            n.syl=a;
        }
        if((sign==2)||(sign==3))    /*布尔表达式处理*/
        {
            pointmark++;
            labelmark[pointmark].nxq1=nxq;
            sp1=0;
            stack1[sp1]=0;
            num=0;
            n1.syl=ibuf[num].syl;
            n1.pos=ibuf[num].pos;
            lrparse2(num);
            labelmark[pointmark].tc1=ntab2[label-1].tc;
            labelmark[pointmark].fc1=ntab2[label-1].fc;
            backpatch(labelmark[pointmark].tc1,nxq);
            n.syl=e;
        }
    }
    lr=action[stack[sp].pos][n.syl];
    printf("stack[%d]=%d\t\tn=%d\t\tlr=%d\n",sp,stack[sp].pos,n.syl,lr);
    if((lr<19)&&(lr>=0))    /*移进*/
    {
        sp++;
        stack[sp].pos=lr;
        stack[sp].syl=n.syl;
        readnu();
        lrparse();
    }
    if((lr<=107)&&(lr>=100))    /*归约*/
    {
        switch(lr)
        {
            case 100:   /*S'->S*/
                break;
            case 101:   /*S->if e then S else S*/
                printf("S->if e then S else S 归约\n");
                sp=sp-6;
                n.syl=S;
                fexp[labeltemp[pointtemp]].result=nxq;
                pointtemp--;
                if(stack[sp].syl==sy_then)
                {
                    gen("j",oth,oth,0);
                    backpatch(labelmark[pointmark].fc1,nxq);
                    pointtemp++;
                    labeltemp[pointtemp]=nxq-1;
                }
                pointmark--;
                if(stack[sp].syl==sy_do)
                {
                    gen("j",oth,oth,labelmark[pointmark].nxq1);
                    backpatch(labelmark[pointmark].fc1,nxq);
                }
                break;
            case 102:   /*S->while e do S*/
                printf("S->while e do s 归约\n");
                sp=sp-4;
                n.syl=S;
                pointmark--;
                if(stack[sp].syl==sy_do)
                {
                    gen("j",oth,oth,labelmark[pointmark].nxq1);
                    backpatch(labelmark[pointmark].fc1,nxq);
                }
                if(stack[sp].syl==sy_then)
                {
                    gen("j",oth,oth,0);
                    fexp[labelmark[pointmark].fc1].result=nxq;
                    pointtemp++;
                    labeltemp[pointtemp]=nxq-1;
                }
                break;
            case 103:   /*S->begin L end*/
                printf("s->begin L end 归约\n");
                sp=sp-3;
                n.syl=S;
                if(stack[sp].syl==sy_then)
                {
                    gen("j",oth,oth,0);
                    backpatch(labelmark[pointmark].fc1,nxq);
                    pointtemp++;
                    labeltemp[pointtemp]=nxq-1;
                }
                if(stack[sp].syl==sy_do)
                {
                    gen("j",oth,oth,labelmark[pointmark].nxq1);
                    backpatch(labelmark[pointmark].fc1,nxq);
                }
                getch();
                break;
            case 104:   /*S->a*/
                printf("S->a 归约\n");
                sp=sp-1;
                n.syl=S;
                if(stack[sp].syl==sy_then)
                {
                    gen("j",oth,oth,0);
                    backpatch(labelmark[pointmark].fc1,nxq);
                    pointtemp++;
                    labeltemp[pointtemp]=nxq-1;
                }
                if(stack[sp].syl==sy_do)
                {
                    gen("j",oth,oth,labelmark[pointmark].nxq1);
                    backpatch(labelmark[pointmark].fc1,nxq);
                }
                break;
            case 105:   /*L->S*/
                printf("L->S 归约\n");
                sp=sp-1;
                n.syl=L;
                break;
            case 106:   /*L->S;L*/
                printf("L->S;L 归约\n");
                sp=sp-3;
                n.syl=L;
                break;
            case 107:   /*S->if e then S */
                printf("S->if e then S 归约\n");
                sp=sp-4;
                n.syl=S;
                fexp[labeltemp[pointtemp]].result=nxq;
                pointtemp--;
                if(stack[sp].syl==sy_then)
                {
                    gen("j",oth,oth,0);
                    backpatch(labelmark[pointmark].fc1,nxq);
                    pointtemp++;
                    labeltemp[pointtemp]=nxq-1;
                }
                pointmark--;
                if(stack[sp].syl==sy_do)
                {
                    gen("j",oth,oth,labelmark[pointmark].nxq1);
                    backpatch(labelmark[pointmark].fc1,nxq);
                }
                break;
        }
        getch();
        pbuf--;
        lrparse();
    }
    if(lr==ACC) return ACC;
}

/*****************************************disp1******************************/
void disp1()
{
    int temp1=0;
    printf("**************************词法分析结果********************\n");
    for(temp1=0;temp1<count;temp1++)
    {
        printf("%d\t%d\n",buf[temp1].syl,buf[temp1].pos);
        if(temp1==20)
        {
            printf("Press any key to continue.....\n");
            getch();
        }
    }
    getch();
}

/**************************************************************************/
void disp2()
{
    int temp1=100;
    printf("\n****************************四元式分析结果*********************\n");
    for(temp1=100;temp1<nxq;temp1++)
    {
    	
        printf("%d\t",temp1);
		printf("%s\t",fexp[temp1].op);
        if(fexp[temp1].arg1.syl==ident)  
			printf("%s\t",ntab1[fexp[temp1].arg1.pos]);
       else
       {
       		if(fexp[temp1].arg1.syl==varconst)  
				printf("%s\t",ntab3[fexp[temp1].arg1.pos]);
			else{
				if(fexp[temp1].arg1.syl==tempsy) 
					printf("T%d\t",fexp[temp1].arg1.pos);
            	else
            	{
					if(fexp[temp1].arg1.syl==intconst)
               			printf("%d\t",fexp[temp1].arg1.pos);
                	else
						printf("\t");
            	}
			}	
       }
       if(fexp[temp1].arg2.syl==ident)  
	   		printf("%s\t",ntab1[fexp[temp1].arg2.pos]);
       else
       {
       		if(fexp[temp1].arg2.syl==varconst)  
				printf("%s\t",ntab3[fexp[temp1].arg2.pos]);
			else{
				if(fexp[temp1].arg2.syl==tempsy)
           			printf("T%d\t",fexp[temp1].arg2.pos);
           		else
           		{
               		if(fexp[temp1].arg2.syl==intconst)
               			printf("%d\t",fexp[temp1].arg2.pos);
               		else printf("\t");
           		}
			}
       }
       if(fexp[temp1].op[0]!='j')
       {
           if(fexp[temp1].result>=100)
           		printf("T%d\t",fexp[temp1].result-100);
           else 
				printf("%s\t",ntab1[fexp[temp1].result]);
       }
       else 
			printf("%d\t",fexp[temp1].result);
       if(temp1==20)
       {
           printf("\nPress any key to continue.....\n");
           getch();
       }
       printf("\n");
    }
    getch();
}

void disp3()
{
    int tttt;
    printf("\n\n程序总共%d行，产生了%d个二元式!",lnum,count);
    getch();
    printf("\n*************************变量名表*************************\n");
    for(tttt=0;tttt<tt1;tttt++)
        printf("%d\t%s\n",tttt,ntab1[tttt]);
    getch();
    printf("\n*************************实数表*************************\n");
    for(tttt=0;tttt<tt3;tttt++)
        printf("%d\t%s\n",tttt,ntab3[tttt]);
    getch();
}


/*****************************主程序***************************************/
int main()
{
    cfile=fopen("pas.txt","r"); /*打开C语言源文件*/
    readch();   /*从源文件读一个字符*/
    scan(); /*词法分析*/
    disp1();
    disp3();
    stack[sp].pos=0;
    stack[sp].syl=-1;   /*初始化状态栈*/
    stack1[sp1]=0;  /*初始化状态栈1*/
    oth.syl=-1;
    printf("\n*******************状态栈加工过程及归约顺序****************\n");
    readnu();   /*从二元式读入一个字符*/
    lrparse();  /*四元式分析*/
    getch();
    disp2();
    printf("\n程序运行结束\n");
    getch();
    return 0;
}

