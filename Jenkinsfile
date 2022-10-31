

# Sample Jenkinsfile for execution
node {
    stage('SCM') {
        git 'https://github.com/naresh1919/time-tracker.git'
    }
    stage('clean') {
        sh label: '', script: 'mvn clean'
    }
    stage('compile test package') {
        sh label: '', script: 'mvn compile test package'
    }

    stage('junit test  Results') {
        junit '**/target/surefire-reports/TEST-*.xml'
    }
    stage('archiveArtifacts') {
        archiveArtifacts 'core/target/*.jar'
        archiveArtifacts 'web/target/*.war'
    }
}
