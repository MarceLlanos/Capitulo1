using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Capitulo1.Namespace
{
    class Calculator
    {
        private double x;
        private double y;

        public Calculator()
        {
            CodeCompileUnit codeCompile = new CodeCompileUnit();
            CodeNamespace codeNamespace = new CodeNamespace("Ellipse");

            CodeTypeDeclaration codeTypeDeclaration = new CodeTypeDeclaration("Ellipse");
            codeTypeDeclaration.IsClass = true;
            codeTypeDeclaration.TypeAttributes = TypeAttributes.Public;
            codeNamespace.Types.Add(codeTypeDeclaration);

            CodeMemberField xField = new CodeMemberField();
            xField.Name = "x";
            xField.Type = new CodeTypeReference(typeof(int));
            codeTypeDeclaration.Members.Add(xField);

            CodeMemberField yField = new CodeMemberField();
            yField.Name = "y";
            yField.Type = new CodeTypeReference(typeof(int));
            codeTypeDeclaration.Members.Add(xField);

            CodeMemberProperty xProperty = new CodeMemberProperty();
            xProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            xProperty.Name = "x";
            xProperty.HasGet = true;
            xProperty.HasSet = true;
            xProperty.Type = new CodeTypeReference(typeof(System.Int32));
            xProperty.GetStatements.Add( new CodeMethodReturnStatement( new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), "x" )));
            xProperty.SetStatements.Add( new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x"), new CodePropertySetValueReferenceExpression()));

            codeTypeDeclaration.Members.Add(xProperty);

            CodeMemberProperty yProperty = new CodeMemberProperty();
            yProperty.Attributes = MemberAttributes.Public | MemberAttributes.Final;
            yProperty.Name = "x";
            yProperty.HasGet = true;
            yProperty.HasSet = true;
            yProperty.Type = new CodeTypeReference(typeof(System.Int32));
            yProperty.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x")));
            yProperty.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), "x"), new CodePropertySetValueReferenceExpression()));

            codeTypeDeclaration.Members.Add(yProperty);

            CodeMemberMethod codeDivideMethod = new CodeMemberMethod();
            codeDivideMethod.Name = "Divide";
            codeDivideMethod.ReturnType = new CodeTypeReference(typeof(int));
            codeDivideMethod.Attributes = MemberAttributes.Public | MemberAttributes.Final;

            CodeConditionStatement ifLogic = new CodeConditionStatement();
            ifLogic.Condition = new CodeBinaryOperatorExpression(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), yProperty.Name), CodeBinaryOperatorType.ValueEquality, new CodePrimitiveExpression(0));
            ifLogic.FalseStatements.Add(new CodeMethodReturnStatement( new CodeBinaryOperatorExpression( new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), xProperty.Name), CodeBinaryOperatorType.Add, new CodeFieldReferenceExpression( new CodeThisReferenceExpression(), yProperty.Name))));
            codeDivideMethod.Statements.Add(ifLogic);

        }

        public double X
        {
            get { return this.x; }
            set { this.x = value; }

        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
        public double Divide()
        {
            if (this.Y == 0)
            {
                return 0;
            }
            else
            {
                return this.X / this.Y;
            }
        }

        public double Exponent(double power)
        {
            return Math.Pow(this.X, power);
        }
    }
}
