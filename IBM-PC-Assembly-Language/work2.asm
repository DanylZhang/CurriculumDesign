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
cmp al,0dh		;�ǻس����˳�����
je exit
cmp al,'a'		;С��a��������
jl next
cmp al,'z'		;����z��������
jg next
mov bl,al			;��������ַ�����bl��
output:
mov dl,bl
dec dl
mov ah,2
int 21h				;���ǰһ���ַ�
mov dl,bl
mov ah,2
int 21h				;������ַ�
mov dl,bl
inc dl
mov ah,2
int 21h				;�����һ���ַ�
jmp crlf
exit:
mov ax,4c00h
int 21h

show proc near
mov ax,data
mov es,ax
lea bp,string
mov cx,len_str
mov dx,0			;������ʼ����
mov ah,0
mov al,3
int 10h				;�����ı���ʾ
mov bl,0eh		;�����ַ�������Ϊ�ڵ׻���
mov ah,13h		;����ַ���
mov al,0
int 10h
ret
show endp
code ends
end start