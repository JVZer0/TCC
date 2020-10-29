import React, { useEffect, useState } from "react";
import { useHistory } from "react-router-dom";
import { Link } from "react-router-dom";

import '../../components/Cabecalho/cabecalho.css'
import '../Meus anuncios/style.css'

import Logo from '../../assets/image/Capturar.PNG'

import anuncioAPI from '../../services/anuncioAPI';
const api = new anuncioAPI();


export default function MeusAnuncios(props){
    const [infos, setInfos] = useState(props.location.state);
    const [meusAnuncios, setMeusAnuncios] = useState([]);

    const consultarMeusAnuncios = async () => {
        try{
            const resp = await api.consultarMeusAnuncios(props.location.state.idUsuario);
            setMeusAnuncios(resp);
        }
        catch (e){

        }
    }
    useEffect(() => {
        consultarMeusAnuncios();
      }, []);

    return(
        <div className="aiai">

            <div className="cabecalho">
                <div>
                    <Link className="hihi" to={{pathname: "/Home", state: infos}} ><img class="logo" src={Logo} width="150" height="27px" alt=''/></Link>
                </div>

                <div className="barraPesquisa hihi">
                    <Link to={{pathname:"/Home", state: infos}}>Fazer novas consultas</Link>
                </div>

                <div className="meio"> 
                    <Link class="hihi meio" to={{ pathname: "/MeuPerfil", state: infos }}>Meu perfil</Link>
                    <Link class="hihi meio" to={{pathname: "/MeusFavoritos", state: infos}}>Meus Favoritos</Link>
                </div>
                <div>
                    <Link  class="hihi" to="/Anunciar"><button class="botao">Anunciar</button></Link>
                </div>
            </div>
            

            <div class="tabela">
                <div className="shit">
                    <table className="table">
                        <thead>
                            <tr>
                                <th>Titulo</th>
                                <th>Preço</th>
                                <th>Data da postagem</th>
                                <th>Situação</th>
                                <th></th>
                                <th></th>
                                <th></th>
                                <th></th>

                            </tr>
                        </thead>

                        <tbody>
                            {meusAnuncios.map(item =>
                                <tr>
                                    <td>{item.titulo}</td>
                                    <td>{item.preco}</td>
                                    <td>{item.dataDePublicacao.substring(0,10)}</td>
                                    <td>{item.situacao}</td>
                                    <td>Editar</td>
                                    <td><Link to={{ pathname: "/ExcluirAnuncio", state: {infos, item}}}>Excluir</Link></td>
                                    <td><Link to={{ pathname: "/InativarAnuncio", state: infos}}>Inativar</Link></td>
                                    <td>Já vendi</td>
                                </tr>    
                            )}
                        </tbody>
                    </table>
                </div>
            </div>

            <div className="rodape">
                    <div className="tey">
                        <h4>Site criado pelo time TK Soluções de Informática. Todos os direitos reservados</h4>
                    </div>
            </div>
        </div>
    )
}