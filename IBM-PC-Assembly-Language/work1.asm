data segment
 maxlen db 32
 actlen db ?
 buffer db 32 dup(?)
 string db 'Please input no more than 32 characters. Press Enter key to changecase and exit.'
 len_str equ $-string
data ends

code segment
assume cs:code,ds:data
start:
lea bp,string
mov cx,len_str
call show				;输出提示信息
call crlf				;回车换行
call getstring	;获取用户输入并存储
call lwr2upr		;小写转大写
lea bp,buffer
sub ch,ch
mov cl,actlen
call show				;输出转换后文本
;mov ch,0ffh		;置ch的第4位为1，不显示光标
;mov ah,1				;置光标类型
;int 10h				;调用BIOS中断
call crlf
mov ah,7
int 21h					;输入任意键退出
mov ax,4c00h
int 21h

show proc near
mov ax,data
mov es,ax
;lea bp,string
;mov cx,len_str
mov dx,0				;设置起始行列
mov ah,0
mov al,3
int 10h					;设置文本显示
mov bl,0eh			;设置字符串属性为黑底黄字
mov ah,13h			;输出字符串
mov al,0
int 10h
ret
show endp

crlf proc near
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h
ret
crlf endp

getstring proc near
mov ax,data
mov ds,ax
lea dx,maxlen
mov ah,0ah
int 21h
ret
getstring endp

lwr2upr proc near
mov ax,data
mov ds,ax
mov bx,0-1
next:
inc bx
cmp bl,actlen
jg exit
mov al,buffer[bx]
cmp al,'a'
jl next
cmp al,'z'
jg next
jle upper

upper:
and al,11011111b
mov buffer[bx],al
jmp next

exit:
ret
lwr2upr endp

code ends
end start