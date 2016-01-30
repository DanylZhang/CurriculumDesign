package calculator;

/*һ����׺ʽת��׺ʽ(�沨��ʽ)�㷨��
 *  1.����ǰ�ַ�Ϊ�����ʱ������ "(",")" ��
 *    a.����ǰ�ַ�Ϊ")"ʱ���򵯳���ջ�����ϵ�"("֮ǰ������������������RPN_expression��Ȼ��ɾ��ջ���������"("
 *    b.����ǰ�ַ���")"ʱ�����ε�����ջ�����ȼ����ڵ��ڵ�ǰ������ģ�����RPN_expression���ٽ���ǰ�����ѹջ
 *  2.����ǰ�ַ�Ϊ����ʱ��ֱ�������RPN_expression��
 *  3.����ǰ�ַ�Ϊ"="ʱ����������ջ�е����ݴ���RPN_expression��
 *���������沨�����ʽ�㷨��
 *  1.����һ��ջ��Ȼ���������ɨ��RPN_expression��ÿ������������ѹ��ջ�У�ÿ����������ţ��͵���ջ��������������
 *  2.�����Ӧ�����㲢�ѽ����ѹ��ջ�У����Ľ����������ջ��
 *  3.����������*/
import java.math.BigDecimal;
import java.util.Stack;

public class Calculate {

	public static BigDecimal Main(String str) throws Exception {
		String RPN_Expression = toRPN(str);
		return calculateRPN(RPN_Expression);
	}

	private static int priority(char c) {// �ж����ȼ�
		switch (c) {
		case '+':
		case '-':
			return 1;
		case '*':
		case '��':
		case '%':
			return 2;
		case '^':
			return 3;
		case '��':
			return 4;
		case '��':
			return 5;
		case '(':
			return 6;
		default:
			return 0;
		}
	}

	private static String toRPN(String str) throws Exception {
		StringBuffer RPN_expression = new StringBuffer();
		Stack<Character> operator = new Stack<Character>();
		operator.push('=');
		int i = 0;
		char ch = str.charAt(i);

		while (ch != '=') {
			if (ch == '+' || ch == '-' || ch == '*' || ch == '��' || ch == '%'
					|| ch == '^' || ch == '��' || ch == '��' || ch == '('
					|| ch == ')') {// 1.����ǰ�ַ�Ϊ�����ʱ������ "(",")" ��
				if (ch == ')') {// a.����ǰ�ַ�Ϊ")"ʱ���򵯳���ջ�����ϵ�"("֮ǰ������������������RPN_expression��Ȼ��ɾ��ջ���������"("
					char temp = operator.peek();
					while (temp != '(') {
						RPN_expression.append(temp);
						operator.pop();
						temp = operator.peek();
					}
					operator.pop();
					ch = str.charAt(++i);
				} else {// b.����ǰ�ַ���")"ʱ�����ε�����ջ�����ȼ����ڵ��ڵ�ǰ������ģ�����RPN_expression���ٽ���ǰ�����ѹջ
					char temp = operator.peek();
					while (priority(temp) >= priority(ch) && temp != '(') {
						RPN_expression.append(temp);
						operator.pop();
						temp = operator.peek();
					}
					operator.push(ch);
					ch = str.charAt(++i);
				}
			} else {// 2.����ǰ�ַ�Ϊ����ʱ��ֱ�������RPN_expression��
				if (!(('0' <= ch && ch <= '9') || ch == '.'))
					throw new Exception("�Ƿ��ַ���");
				while (('0' <= ch && ch <= '9') || ch == '.') {
					RPN_expression.append(ch);
					ch = str.charAt(++i);
				}
				RPN_expression.append('#');// '#'��������������
			}
		}
		ch = operator.pop();
		while (ch != '=') {// 3.����ǰ�ַ�Ϊ"="ʱ����������ջ�е����ݴ���RPN_expression��
			RPN_expression.append(ch);
			ch = operator.pop();
		}
		RPN_expression.append('=');
		return RPN_expression.toString();
	}

	private static BigDecimal calculateRPN(String str) throws Exception {
		Stack<BigDecimal> stack = new Stack<BigDecimal>();
		BigDecimal num1, num2;
		StringBuffer operand;
		int i = 0;
		while (str.charAt(i) != '=') {
			operand = new StringBuffer();
			if ('0' <= str.charAt(i) && str.charAt(i) <= '9') {
				while (('0' <= str.charAt(i) && str.charAt(i) <= '9')
						|| str.charAt(i) == '.') {
					operand.append(str.charAt(i++));
				}
				try {
					stack.push(new BigDecimal(operand.toString()));
				} catch (Exception e) {
					throw new Exception("���Ƿ�С���㣡");
				}
			} else if (str.charAt(i) == '#') {
				i++;
			} else if (str.charAt(i) == '+') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num1.add(num2));
				i++;
			} else if (str.charAt(i) == '-') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num2.subtract(num1));
				i++;
			} else if (str.charAt(i) == '*') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num1.multiply(num2));
				i++;
			} else if (str.charAt(i) == '��') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push((num2.divide(num1, 12, BigDecimal.ROUND_HALF_EVEN))
						.stripTrailingZeros());
				i++;
			} else if (str.charAt(i) == '%') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				stack.push(num2.remainder(num1));
				i++;
			} else if (str.charAt(i) == '^') {
				if (stack.size() < 2)
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				num2 = stack.pop();
				if (num1.intValue() < 0)
					throw new Exception("ָ������С���㣡");
				else
					stack.push(num2.pow(num1.intValue()));
				i++;
			} else if (str.charAt(i) == '��') {
				if (stack.size() < 1)// ����Ϊ��Ŀ�����
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				stack.push(num1.negate());
				i++;
			} else if (str.charAt(i) == '��') {
				if (stack.size() < 1)// ����Ϊ��Ŀ�����
					throw new Exception("ȱ�ټ�������");
				num1 = stack.pop();
				if (num1.intValue() < 0)
					throw new Exception("������������С���㣡");
				stack.push(new BigDecimal(Math.sqrt(num1.doubleValue())));
				i++;
			}
		}
		if (stack.size() != 1)// ÿ������ջ��Ӧֻʣһ��������
			throw new Exception("ȱ�ټ�������");
		return stack.pop();
	}
}