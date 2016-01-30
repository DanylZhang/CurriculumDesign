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
call show				;�����ʾ��Ϣ
call crlf				;�س�����
call getstring	;��ȡ�û����벢�洢
call lwr2upr		;Сдת��д
lea bp,buffer
sub ch,ch
mov cl,actlen
call show				;���ת�����ı�
;mov ch,0ffh		;��ch�ĵ�4λΪ1������ʾ���
;mov ah,1				;�ù������
;int 10h				;����BIOS�ж�
call crlf
mov ah,7
int 21h					;����������˳�
mov ax,4c00h
int 21h

show proc near
mov ax,data
mov es,ax
;lea bp,string
;mov cx,len_str
mov dx,0				;������ʼ����
mov ah,0
mov al,3
int 10h					;�����ı���ʾ
mov bl,0eh			;�����ַ�������Ϊ�ڵ׻���
mov ah,13h			;����ַ���
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