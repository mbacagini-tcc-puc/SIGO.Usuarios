pipeline {
	agent any 
	stages {
		stage('Build image') {
			steps {
				sh "docker build -f src/SIGO.Usuarios.API/Dockerfile -t sigo-usuarios ."
				sh "docker tag sigo-usuarios ${params.ECR_Repo}/sigo-usuarios:latest"
			}
		}
		
		stage('Push image') {
			steps {
				sh "aws ecr get-login-password --region sa-east-1 | docker login --username AWS --password-stdin ${params.ECR_Repo}"
				sh "docker push ${params.ECR_Repo}/sigo-usuarios:latest"
			}
		}
	}
}