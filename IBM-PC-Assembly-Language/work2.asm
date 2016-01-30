data segment
 string db 'Please input a lower case. Press Enter key exit.'
 len_str equ $-string
data ends

code segment
assume cs:code,ds:data
start:
call show
crlf:
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h

next:
mov ah,07h
int 21h
cmp al,0dh		;是回车就退出程序
je exit
cmp al,'a'		;小于a重新输入
jl next
cmp al,'z'		;大于z重新输入
jg next
mov bl,al			;将输入的字符放入bl中
output:
mov dl,bl
dec dl
mov ah,2
int 21h				;输出前一个字符
mov dl,bl
mov ah,2
int 21h				;输出本字符
mov dl,bl
inc dl
mov ah,2
int 21h				;输出后一个字符
jmp crlf
exit:
mov ax,4c00h
int 21h

show proc near
mov ax,data
mov es,ax
lea bp,string
mov cx,len_str
mov dx,0			;设置起始行列
mov ah,0
mov al,3
int 10h				;设置文本显示
mov bl,0eh		;设置字符串属性为黑底黄字
mov ah,13h		;输出字符串
mov al,0
int 10h
ret
show endp
code ends
end start