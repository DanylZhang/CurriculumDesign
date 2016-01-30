data segment
 MEM dw 1,0,32,6,9,0,2,35,26,-1,-24,0,6,0,0,0,45,21,0,75	;20个
     dw 10 dup(3)
     dw 10 dup(4)
     dw 10 dup(5)
     dw 10 dup(0)
     dw 10 dup(7)
     dw 10 dup(8)
     dw 10 dup(9)
     dw 10 dup(0)
data ends

code segment
assume cs:code,ds:data
start:
mov ax,data
mov ds,ax
begin:
mov si,(100-1)*2		;使si指向MEM的末元素的地址
mov bx,0-2			;地址指针的初值
mov cx,100			;控制做100次循环
comp:
add bx,2
comp1:
cmp MEM[bx],0
jz cons
loop comp
jmp exit			;比较完了，已无0则结束

cons:
mov di,bx

cons1:
cmp di,si			;是否是最后一个元素？
jae zero
mov ax,MEM[di+2]		;后面的元素向前移位
mov MEM[di],ax
add di,2
jmp cons1
zero:
mov word ptr [si],0		;最后元素置零
loop comp1			;跳转到bx不加2继续循环

exit:
mov dl,'*'
mov ah,2
int 21h
mov ah,7
int 21h
mov ax,4c00h
int 21h
code ends
end start