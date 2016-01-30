data segment
 M dw 1,1,2,-2,3,-3,4,-4,5,-5,6,-6,7,-7,8,-8,9,-9,10,-10
 P dw 20 dup(?)
 N dw 20 dup(?)
 P_count db 0
 N_count db 0
 Pos_string db 'Positive numbers:$'
 Neg_string db 'Negative numbers:$'
 Exit_string db 'Press any key to exit...$'
data ends

mystack segment
 stack1 dw 2 dup(0)
mystack ends

code segment
main proc far
assume cs:code,ds:data,ss:mystack
start:
mov ax,data
mov ds,ax
mov ax,mystack
mov ss,ax
mov sp,10

mov bx,0-2
mov si,0			;正数数组指针
mov di,0			;负数数组指针
mov cx,20+1
next:
add bx,2
dec cx
jz print
test M[bx],0ffffh
js negative

positive:
mov ax,M[bx]
mov ds:P[si],ax
inc P_count
add si,2
jmp next

negative:
mov ax,M[bx]
mov ds:N[di],ax
inc N_count
add di,2
jmp next

print:
lea dx,Pos_string
mov ah,9
int 21h
mov al,P_count
mov cx,2
P_next:
cwd
aam
mov dl,al			;余数在al中
mov dh,0
push dx
mov al,ah
cmp al,0
loopne P_next	;二进制转十进制并压栈
mov cx,2
P_out:
pop dx
add dl,30h
mov ah,2
int 21h
cmp sp,10
loopnz P_out
call crlf

lea dx,Neg_string
mov ah,9
int 21h
mov al,N_count
mov cx,2
N_next:
cwd
aam
mov dl,al			;余数在al中
mov dh,0
push dx
mov al,ah
cmp al,0
loopne N_next	;二进制转十进制并压栈
mov cx,2
N_out:
pop dx
add dl,30h
mov ah,2
int 21h
cmp sp,10
loopnz N_out
call crlf
call exit
ret
main endp

crlf proc near
mov dl,0dh
mov ah,2
int 21h
mov dl,0ah
mov ah,2
int 21h
ret
crlf endp

exit proc near
mov ax,data
mov ds,ax
lea dx,Exit_string
mov ah,9
int 21h
mov ah,7
int 21h
mov ax,4c00h
int 21h
ret
exit endp

code ends
end start