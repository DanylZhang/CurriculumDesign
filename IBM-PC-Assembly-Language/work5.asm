data segment
 string db 'Please input N:'
 len_str equ $-string
data ends

code segment
assume cs:code,ds:data
start:
call show
call crlf

next:
mov ah,7
int 21h
cmp al,'0'
jl next
cmp al,'9'
jg next
cmp al,'0'
je exit

mov dl,al
mov ah,2
int 21h

sub al,30h
mov bl,al
bell:
mov dl,7
mov ah,2
int 21h
dec bl
jnz bell

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

crlf proc near
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h
ret
crlf endp
code ends
end start