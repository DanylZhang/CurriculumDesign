data segment
 string1 db 'I have a dog.'
 string2 db 'I have a cat.'
 match db 'MATCH$'
 no_match db 'NO MATCH$'
data ends

code segment
assume cs:code,ds:data
start:
mov ax,data
mov ds,ax
mov es,ax
lea si,string1
lea di,string2

mov cx,13
cld
repe cmpsb
jne diff
lea dx,match
mov ah,9
int 21h
jmp exit

diff:
lea dx,no_match
mov ah,9
int 21h

exit:
mov ax,4c00h
int 21h
code ends
end start