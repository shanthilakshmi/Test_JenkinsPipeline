node {
    stage('SCM') {
        git 'https://github.com/shanthilakshmi/Test_JenkinsPipeline.git'
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
